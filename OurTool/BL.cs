
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Messages;
using System.Diagnostics;
using Microsoft.Xrm.Sdk.Metadata;
using System.Linq;
using Microsoft.Crm.Sdk.Messages;
using System.Drawing;
using System.Web.Security;

namespace OurCRMTool
{
    public class BL
    {
        #region Variables/Members/Properties

        //        private OrganizationServiceProxy service;
        public IOrganizationService service;
        CRMHelpper crmHelper;
        public string url;
        string _resourcesPath;
        private Image userImage = null;
        private Image BUImage = null;
        private Image parentImage = null;
        private Image orgImage = null;
        private Image noneImage = null;
        log4net.ILog log;

        public BL(string _url, string dom, string user, string pass, log4net.ILog _log)
        {
            log = _log;
            crmHelper = new CRMHelpper(log);
            if (dom == string.Empty)
            {
                service = crmHelper.GetCRMServiceOnline(user, pass, _url);
            }
            else
            {
                service = crmHelper.GetCRMService(_url, dom, user, pass);
            }
            url = _url;
        }

        public string ResourcesPath
        {
            get
            {
                if (_resourcesPath == null)
                {
                    string runningPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    _resourcesPath = runningPath + "\\Resources";
                }
                return _resourcesPath;
            }
        }

        #endregion

        #region User
        public EntityCollection GetUsersByTeam(List<Guid> teamId)
        {
            EntityCollection users = new EntityCollection();
            if (teamId.Count > 0)
            {
                QueryExpression userQuery = new QueryExpression("systemuser");
                userQuery.ColumnSet = new ColumnSet(true);

                LinkEntity teamMembershipLink = new LinkEntity("systemuser", "teammembership", "systemuserid", "systemuserid", JoinOperator.Inner);
                teamMembershipLink.Columns = new ColumnSet("teamid");
                teamMembershipLink.EntityAlias = "teamMembership";

                FilterExpression filterTeam = new FilterExpression(LogicalOperator.Or);
                foreach (Guid t in teamId)
                {
                    filterTeam.AddCondition(new ConditionExpression("teamid", ConditionOperator.Equal, t));
                }

                teamMembershipLink.LinkCriteria.AddFilter(filterTeam);

                userQuery.LinkEntities.Add(teamMembershipLink);
                userQuery.Distinct = true;
                userQuery.Orders.Add(new OrderExpression("fullname", OrderType.Ascending));

                users = service.RetrieveMultiple(userQuery);
            }
            return users;
        }

        public EntityCollection GetUsersByBU(Guid businessUnitId)
        {
            EntityCollection users = new EntityCollection();

            QueryExpression userQuery = new QueryExpression("systemuser");
            userQuery.ColumnSet = new ColumnSet("fullname", "systemuserid");
            userQuery.Criteria.AddCondition(new ConditionExpression("businessunitid", ConditionOperator.Equal, businessUnitId));

            users = service.RetrieveMultiple(userQuery);

            return users;
        }

        public EntityCollection GetAllUsers()
        {
            EntityCollection users = new EntityCollection();

            int pageNumber = 1;
            QueryExpression userQuery = new QueryExpression("systemuser");
            userQuery.ColumnSet = new ColumnSet("fullname", "internalemailaddress", "systemuserid");
            userQuery.PageInfo = new PagingInfo();
            userQuery.PageInfo.PageNumber = pageNumber;
            userQuery.PageInfo.PagingCookie = null;

            while (true)
            {
                // Retrieve the page.
                EntityCollection results = service.RetrieveMultiple(userQuery);
                if (results.Entities != null)
                {
                    users.Entities.AddRange(results.Entities);
                }

                // Check for more records, if it returns true.
                if (results.MoreRecords)
                {
                    // Increment the page number to retrieve the next page.
                    userQuery.PageInfo.PageNumber++;

                    // Set the paging cookie to the paging cookie returned from current results.
                    userQuery.PageInfo.PagingCookie = results.PagingCookie;
                }
                else
                {
                    // If no more records are in the result nodes, exit the loop.
                    break;
                }
            }

            return users;
        }

        /// <summary>
        /// Will returnt all the users that have no default team, with all the related teams
        /// </summary>
        /// <returns></returns>
        public EntityCollection GetUsersWithoutDefaultTeam(bool is2016 = false)
        {
            EntityCollection users = new EntityCollection();
            QueryExpression userQuery = new QueryExpression("systemuser");
            userQuery.ColumnSet = new ColumnSet("fullname", "domainname", "systemuserid");
            userQuery.Criteria.AddCondition("isdisabled", ConditionOperator.Equal, false);
            if (is2016)
            {
                userQuery.Criteria.AddCondition("xnes_teamid", ConditionOperator.Null);
            }
            else
            {
                userQuery.Criteria.AddCondition("new_id_related_team", ConditionOperator.Null);
            }
            LinkEntity teamMLink = new LinkEntity("systemuser", "teammembership", "systemuserid", "systemuserid", JoinOperator.Inner);
            teamMLink.Columns = new ColumnSet("teamid");
            teamMLink.EntityAlias = "teammembership";


            LinkEntity teamLink = new LinkEntity("teammembership", "team", "teamid", "teamid", JoinOperator.Inner);
            teamLink.Columns = new ColumnSet("name", "teamid");
            teamLink.EntityAlias = "team";
            teamMLink.LinkEntities.Add(teamLink);

            userQuery.LinkEntities.Add(teamMLink);

            users = service.RetrieveMultiple(userQuery);
            return users;
        }

        public EntityCollection GetUsersWithDafultTeam()
        {

            EntityCollection users = new EntityCollection();
            QueryExpression userQuery = new QueryExpression("systemuser");
            userQuery.ColumnSet = new ColumnSet("fullname", "systemuserid", "new_id_related_team");
            userQuery.Criteria.AddCondition("isdisabled", ConditionOperator.Equal, false);
            userQuery.Criteria.AddCondition("new_id_related_team", ConditionOperator.NotNull);

            users = service.RetrieveMultiple(userQuery);
            return users;
        }

        public string DeleteDefaultTeams(List<Guid> usersId)
        {
            ExecuteMultipleRequest requestWithResults = new ExecuteMultipleRequest()
            {
                // Assign settings that define execution behavior: continue on error, return responses. 
                Settings = new ExecuteMultipleSettings()
                {
                    ContinueOnError = false,
                    ReturnResponses = true
                },
                // Create an empty organization request collection.
                Requests = new OrganizationRequestCollection()
            };

            foreach (Guid u in usersId)
            {
                Entity user = new Entity("systemuser");
                user.Id = u;
                UpdateRequest updateReq = new UpdateRequest();
                updateReq.Target = user;
                user["new_id_related_team"] = null;
                requestWithResults.Requests.Add(updateReq);
            }
            ExecuteMultipleResponse resp = (ExecuteMultipleResponse)service.Execute(requestWithResults);
            string retMessage = "Finish Succefuly";
            if (resp.IsFaulted == true)
            {
                retMessage = "Finished with errors:" + Environment.NewLine;
                for (int i = 0; i < resp.Responses.Count; i++)
                {
                    if (resp.Responses[i].Fault != null)
                    {
                        retMessage += "Error in item Nr: " + (i + 1).ToString() + "-> " + resp.Responses[i].Fault.Message;
                    }
                }
            }
            return retMessage;
        }
        public EntityCollection GetUserWithRole(List<string> roleNames)
        {

            QueryExpression query = new QueryExpression("systemuserroles");

            LinkEntity linkRole = new LinkEntity("systemuserroles", "role", "roleid", "roleid", JoinOperator.Inner);
            linkRole.Columns = new ColumnSet("name");    //role's name
            linkRole.EntityAlias = "role";
            linkRole.LinkCriteria.AddCondition(new ConditionExpression("name", ConditionOperator.In, roleNames));

            LinkEntity linkUser = new LinkEntity("systemuserroles", "systemuser", "systemuserid", "systemuserid", JoinOperator.Inner);
            linkUser.Columns = new ColumnSet("domainname", "systemuserid", "fullname");
            linkUser.EntityAlias = "user";
            linkUser.LinkCriteria.AddCondition(new ConditionExpression("isdisabled", ConditionOperator.Equal, false));

            query.LinkEntities.Add(linkRole);
            query.LinkEntities.Add(linkUser);

            EntityCollection collection = service.RetrieveMultiple(query);
            return collection;
        }

        #endregion

        #region Team

        public EntityCollection GetTeams(Guid BusinessUnitId)
        {

            QueryExpression teamQuery = new QueryExpression("team");
            teamQuery.Criteria.AddCondition("businessunitid", ConditionOperator.Equal, BusinessUnitId);
            teamQuery.ColumnSet = new ColumnSet("name");
            teamQuery.Orders.Add(new OrderExpression("name", OrderType.Ascending));

            return service.RetrieveMultiple(teamQuery);
        }

        public EntityCollection GetTeams(List<Guid> BusinessUnitsId)
        {
            QueryExpression teamQuery = new QueryExpression("team");
            teamQuery.ColumnSet = new ColumnSet("name");

            FilterExpression filter = new FilterExpression(LogicalOperator.Or);
            foreach (Guid bu in BusinessUnitsId)
            {
                filter.AddCondition("businessunitid", ConditionOperator.Equal, bu);
            }
            teamQuery.Criteria.AddFilter(filter);
            return service.RetrieveMultiple(teamQuery);
        }

        public EntityCollection GetTeamsByName(List<string> teamName)
        {

            QueryExpression teamQuery = new QueryExpression("team");
            teamQuery.ColumnSet = new ColumnSet("name");

            FilterExpression filter = new FilterExpression(LogicalOperator.Or);
            foreach (string n in teamName)
            {
                filter.AddCondition("name", ConditionOperator.Equal, n);
            }
            teamQuery.Criteria.AddFilter(filter);
            return service.RetrieveMultiple(teamQuery);
        }

        public EntityCollection GetTeamsWithRole(List<string> roleNames)
        {
            QueryExpression query = new QueryExpression("teamroles");

            LinkEntity linkRole = new LinkEntity("teamroles", "role", "roleid", "roleid", JoinOperator.Inner);
            linkRole.Columns = new ColumnSet("name");    //role's name
            linkRole.EntityAlias = "role";
            linkRole.LinkCriteria.AddCondition(new ConditionExpression("name", ConditionOperator.In, roleNames));

            LinkEntity linkTeam = new LinkEntity("teamroles", "team", "teamid", "teamid", JoinOperator.Inner);
            linkTeam.Columns = new ColumnSet("name", "teamid");
            linkTeam.EntityAlias = "team";

            query.LinkEntities.Add(linkRole);
            query.LinkEntities.Add(linkTeam);

            EntityCollection collection = service.RetrieveMultiple(query);
            return collection;
        }

        public EntityCollection GetTeamsByUser(Guid userId)
        {
            QueryExpression teamQuery = new QueryExpression("teammembership");
            teamQuery.Criteria.AddCondition("systemuserid", ConditionOperator.Equal, userId);

            LinkEntity linkTeam = new LinkEntity("teammembership", "team", "teamid", "teamid", JoinOperator.Inner);
            linkTeam.EntityAlias = "team";
            linkTeam.Columns = new ColumnSet("name", "teamid");

            teamQuery.LinkEntities.Add(linkTeam);

            return service.RetrieveMultiple(teamQuery);
        }

        #endregion

        #region Entity

        public RetrieveAllEntitiesResponse GetEntities()
        {
            RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest()
            {
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = true
            };

            // Retrieve the MetaData.
            return (RetrieveAllEntitiesResponse)service.Execute(request);
        }

        #endregion


        public EntityCollection GetAllContacts()
        {
            EntityCollection contacts = new EntityCollection();

            int pageNumber = 1;
            QueryExpression query = new QueryExpression("contact");
            query.ColumnSet = new ColumnSet("fullname", "emailaddress1", "contactid");
            query.PageInfo = new PagingInfo();
            query.PageInfo.PageNumber = pageNumber;
            query.PageInfo.PagingCookie = null;

            while (true)
            {
                // Retrieve the page.
                EntityCollection results = service.RetrieveMultiple(query);
                if (results.Entities != null)
                {
                    contacts.Entities.AddRange(results.Entities);
                }

                // Check for more records, if it returns true.
                if (results.MoreRecords)
                {
                    // Increment the page number to retrieve the next page.
                    query.PageInfo.PageNumber++;

                    // Set the paging cookie to the paging cookie returned from current results.
                    query.PageInfo.PagingCookie = results.PagingCookie;
                }
                else
                {
                    // If no more records are in the result nodes, exit the loop.
                    break;
                }
            }

            return contacts;
        }

        public EntityCollection GetAllAccounts()
        {
            EntityCollection accounts = new EntityCollection();

            int pageNumber = 1;
            QueryExpression query = new QueryExpression("account");
            query.ColumnSet = new ColumnSet("name", "emailaddress1", "accountid");
            query.PageInfo = new PagingInfo();
            query.PageInfo.PageNumber = pageNumber;
            query.PageInfo.PagingCookie = null;

            while (true)
            {
                // Retrieve the page.
                EntityCollection results = service.RetrieveMultiple(query);
                if (results.Entities != null)
                {
                    accounts.Entities.AddRange(results.Entities);
                }

                // Check for more records, if it returns true.
                if (results.MoreRecords)
                {
                    // Increment the page number to retrieve the next page.
                    query.PageInfo.PageNumber++;

                    // Set the paging cookie to the paging cookie returned from current results.
                    query.PageInfo.PagingCookie = results.PagingCookie;
                }
                else
                {
                    // If no more records are in the result nodes, exit the loop.
                    break;
                }
            }

            return accounts;
        }

        public EntityCollection GetAllLeads()
        {
            EntityCollection leads = new EntityCollection();

            int pageNumber = 1;
            QueryExpression query = new QueryExpression("lead");
            query.ColumnSet = new ColumnSet("subject", "emailaddress1", "leadid");
            query.PageInfo = new PagingInfo();
            query.PageInfo.PageNumber = pageNumber;
            query.PageInfo.PagingCookie = null;

            while (true)
            {
                // Retrieve the page.
                EntityCollection results = service.RetrieveMultiple(query);
                if (results.Entities != null)
                {
                    leads.Entities.AddRange(results.Entities);
                }

                // Check for more records, if it returns true.
                if (results.MoreRecords)
                {
                    // Increment the page number to retrieve the next page.
                    query.PageInfo.PageNumber++;

                    // Set the paging cookie to the paging cookie returned from current results.
                    query.PageInfo.PagingCookie = results.PagingCookie;
                }
                else
                {
                    // If no more records are in the result nodes, exit the loop.
                    break;
                }
            }

            return leads;
        }

        #region Security Roles

        /// <summary>
        /// Will return the security roles that have the selected AccessRight, privilefeDepth for the Entity
        /// </summary>
        /// <param name="objectTypeCode"></param>
        /// <param name="accessRigth"></param>
        /// <param name="privilegeDepthMask"></param>
        /// <returns></returns>
        public EntityCollection GetSecurityRolesWithPrivilege(int objectTypeCode, List<int> accessRigth, List<int> privilegeDepthMask)
        {
            EntityCollection collection = null;
            if (accessRigth != null && privilegeDepthMask != null)
            {
                QueryExpression query = new QueryExpression("privilege");
                query.Criteria.AddCondition(new ConditionExpression("accessright", ConditionOperator.In, accessRigth));
                query.ColumnSet = new ColumnSet("accessright");

                LinkEntity linkObjectTypeCode = new LinkEntity("privilege", "privilegeobjecttypecodes", "privilegeid", "privilegeid", JoinOperator.Inner);
                linkObjectTypeCode.LinkCriteria.AddCondition("objecttypecode", ConditionOperator.Equal, objectTypeCode);
                linkObjectTypeCode.EntityAlias = "OTypeCode";

                LinkEntity linkRolePrivileges = new LinkEntity("privilege", "roleprivileges", "privilegeid", "privilegeid", JoinOperator.Inner);
                linkRolePrivileges.LinkCriteria.AddCondition(new ConditionExpression("privilegedepthmask", ConditionOperator.In, privilegeDepthMask));
                linkRolePrivileges.Columns = new ColumnSet("privilegedepthmask");
                linkRolePrivileges.EntityAlias = "roleP";

                LinkEntity linkRole = new LinkEntity("roleprivileges", "role", "roleid", "roleid", JoinOperator.Inner);
                linkRole.Columns = new ColumnSet("name", "roleid", "ismanaged");    //role's name
                linkRole.EntityAlias = "role";

                linkRolePrivileges.LinkEntities.Add(linkRole);

                query.LinkEntities.Add(linkObjectTypeCode);
                query.LinkEntities.Add(linkRolePrivileges);

                collection = service.RetrieveMultiple(query);
            }
            return collection;
        }

        /// <summary>
        /// Get roles for the selected businessUnit
        /// </summary>
        /// <param name="BusinessUnit"></param>
        /// <returns></returns>
        public EntityCollection GetAllSecurityRoles()
        {
            QueryExpression queryRole = new QueryExpression("role");
            queryRole.Criteria.AddCondition(new ConditionExpression("parentroleid", ConditionOperator.Null));
            queryRole.ColumnSet = new ColumnSet("name", "roleid", "businessunitid", "createdon", "createdby");
            queryRole.Orders.Add(new OrderExpression("name", OrderType.Ascending));

            return service.RetrieveMultiple(queryRole);
        }

        public EntityCollection GetNotUsedRoles()
        {

            QueryExpression UserRolesQuery = new QueryExpression("systemuserroles");
            UserRolesQuery.ColumnSet = new ColumnSet("roleid");
            EntityCollection userRoles = service.RetrieveMultiple(UserRolesQuery);


            QueryExpression TeamRolesQuery = new QueryExpression("teamroles");
            UserRolesQuery.ColumnSet = new ColumnSet("roleid");
            EntityCollection teamRoles = service.RetrieveMultiple(UserRolesQuery);


            QueryExpression RoleQuery = new QueryExpression("role");
            RoleQuery.Criteria.AddCondition(new ConditionExpression("parentroleid", ConditionOperator.Null));
            RoleQuery.Criteria.AddCondition(new ConditionExpression("roleid", ConditionOperator.NotIn, userRoles.Entities.Select(a => a.GetAttributeValue<Guid>("roleid")).ToArray()));
            RoleQuery.Criteria.AddCondition(new ConditionExpression("roleid", ConditionOperator.NotIn, teamRoles.Entities.Select(a => a.GetAttributeValue<Guid>("roleid")).ToArray()));
            RoleQuery.ColumnSet = new ColumnSet("name", "roleid", "businessunitid", "createdby", "createdon");
            RoleQuery.Orders.Add(new OrderExpression("name", OrderType.Ascending));

            LinkEntity linkBU = new LinkEntity("role", "businessunit", "businessunitid", "businessunitid", JoinOperator.Inner);
            linkBU.Columns = new ColumnSet("name");
            linkBU.EntityAlias = "businessunit";

            LinkEntity linkUser = new LinkEntity("role", "systemuser", "createdby", "systemuserid", JoinOperator.Inner);
            linkUser.Columns = new ColumnSet("fullname");
            linkUser.EntityAlias = "user";

            RoleQuery.LinkEntities.Add(linkBU);
            RoleQuery.LinkEntities.Add(linkUser);

            EntityCollection roles = service.RetrieveMultiple(RoleQuery);

            return roles;
        }

        /// <summary>
        /// Will return all the privilege that the role has
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public EntityCollection GetPrivilege(Guid roleId)
        {
            EntityCollection collection = null;
            QueryExpression query = new QueryExpression("privilege");
            query.ColumnSet = new ColumnSet("accessright", "name");

            LinkEntity linkObjectTypeCode = new LinkEntity("privilege", "privilegeobjecttypecodes", "privilegeid", "privilegeid", JoinOperator.Inner);
            linkObjectTypeCode.EntityAlias = "objecttypecodes";
            linkObjectTypeCode.Columns = new ColumnSet("objecttypecode");

            LinkEntity linkRolePrivileges = new LinkEntity("privilege", "roleprivileges", "privilegeid", "privilegeid", JoinOperator.Inner);
            linkRolePrivileges.Columns = new ColumnSet("privilegedepthmask");
            linkRolePrivileges.EntityAlias = "roleP";

            LinkEntity linkRole = new LinkEntity("roleprivileges", "role", "roleid", "roleid", JoinOperator.Inner);
            linkRole.Columns = new ColumnSet("name", "roleid");    //role's name
            linkRole.LinkCriteria.AddCondition(new ConditionExpression("roleid", ConditionOperator.Equal, roleId));
            linkRole.EntityAlias = "role";

            linkRolePrivileges.LinkEntities.Add(linkRole);

            query.LinkEntities.Add(linkObjectTypeCode);
            query.LinkEntities.Add(linkRolePrivileges);

            collection = service.RetrieveMultiple(query);

            return collection;
        }

        public EntityCollection GetPrivilegeByRoleAndEntity(Guid roleId, int objectTypeCode)
        {
            EntityCollection collection = null;
            QueryExpression query = new QueryExpression("privilege");
            query.ColumnSet = new ColumnSet("accessright", "name");

            LinkEntity linkObjectTypeCode = new LinkEntity("privilege", "privilegeobjecttypecodes", "privilegeid", "privilegeid", JoinOperator.Inner);
            linkObjectTypeCode.LinkCriteria.AddCondition("objecttypecode", ConditionOperator.Equal, objectTypeCode);
            linkObjectTypeCode.EntityAlias = "objecttypecodes";
            linkObjectTypeCode.Columns = new ColumnSet("objecttypecode");

            LinkEntity linkRolePrivileges = new LinkEntity("privilege", "roleprivileges", "privilegeid", "privilegeid", JoinOperator.Inner);
            linkRolePrivileges.Columns = new ColumnSet("privilegedepthmask");
            linkRolePrivileges.EntityAlias = "roleP";

            LinkEntity linkRole = new LinkEntity("roleprivileges", "role", "roleid", "roleid", JoinOperator.Inner);
            linkRole.Columns = new ColumnSet("name", "roleid", "ismanaged");    //role's name
            linkRole.LinkCriteria.AddCondition(new ConditionExpression("roleid", ConditionOperator.Equal, roleId));
            linkRole.EntityAlias = "role";

            linkRolePrivileges.LinkEntities.Add(linkRole);

            query.LinkEntities.Add(linkObjectTypeCode);
            query.LinkEntities.Add(linkRolePrivileges);

            collection = service.RetrieveMultiple(query);

            return collection;
        }

        /// <summary>
        /// Will get all the privilege that are not related to an entity, that are global privilege
        /// </summary>
        /// <returns></returns>
        public EntityCollection GetGlobalPrivilege()
        {
            EntityCollection collection = null;
            QueryExpression query = new QueryExpression("privilege");
            query.ColumnSet = new ColumnSet("name");
            query.Orders.Add(new OrderExpression("name", OrderType.Ascending));

            LinkEntity linkObjectTypeCode = new LinkEntity("privilege", "privilegeobjecttypecodes", "privilegeid", "privilegeid", JoinOperator.Inner);
            linkObjectTypeCode.LinkCriteria.AddCondition(new ConditionExpression("objecttypecode", ConditionOperator.Equal, "none"));

            query.LinkEntities.Add(linkObjectTypeCode);

            collection = service.RetrieveMultiple(query);

            return collection;
        }

        public EntityCollection GetRolesByUserId(EntityReference userTeamRef)
        {
            QueryExpression queryRole = new QueryExpression("role");
            //queryRole.Criteria.AddCondition(new ConditionExpression("parentroleid", ConditionOperator.Null));
            queryRole.ColumnSet = new ColumnSet("name", "roleid", "parentroleid", "businessunitid", "createdon", "createdby");
            queryRole.Orders.Add(new OrderExpression("name", OrderType.Ascending));

            LinkEntity linkUserOrTeam = new LinkEntity("role", userTeamRef.LogicalName + "roles", "roleid", "roleid", JoinOperator.Inner);
            linkUserOrTeam.EntityAlias = "userOrTeamRoles";
            linkUserOrTeam.LinkCriteria.AddCondition(new ConditionExpression(userTeamRef.LogicalName + "id", ConditionOperator.Equal, userTeamRef.Id));

            queryRole.LinkEntities.Add(linkUserOrTeam);

            EntityCollection userRoles = service.RetrieveMultiple(queryRole);

            return GetParentsRoles(userRoles);
        }

        private EntityCollection GetParentsRoles(EntityCollection rolesCol)
        {
            EntityCollection parentRoles = new EntityCollection();
            if (rolesCol.Entities.Count() > 0)
            {
                QueryExpression query = new QueryExpression("role");
                query.ColumnSet = new ColumnSet("name", "roleid", "parentroleid", "businessunitid", "createdon", "createdby");
                query.Criteria.AddCondition(new ConditionExpression("parentroleid", ConditionOperator.Null));

                FilterExpression filterOr = new FilterExpression(LogicalOperator.Or);
                foreach (Entity r in rolesCol.Entities)
                {
                    if (r.Contains("name"))
                    {
                        filterOr.AddCondition(new ConditionExpression("name", ConditionOperator.Equal, r.GetAttributeValue<string>("name")));
                    }
                }
                if (filterOr.Conditions.Count() > 0)
                {
                    query.Criteria.AddFilter(filterOr);
                }
                parentRoles = service.RetrieveMultiple(query);
            }
            return parentRoles;
        }

        public void OpenRole(string roleId)
        {
            string crmPath = url.Substring(0, url.IndexOf("XRMServices")) + "biz/roles/edit.aspx?id=" + roleId;
            Process.Start("IExplore.exe", crmPath);
        }

        #endregion

        public EntityCollection GetBusinessUnit()
        {
            QueryExpression businessUnitQuery = new QueryExpression("businessunit");
            businessUnitQuery.ColumnSet = new ColumnSet("name");

            return service.RetrieveMultiple(businessUnitQuery);
        }

        /// <summary>
        /// Get all the publis dashboards
        /// </summary>
        /// <returns></returns>
        public EntityCollection GetSystemDashBoards()
        {
            QueryExpression DBQuery = new QueryExpression("systemform");
            DBQuery.ColumnSet = new ColumnSet("name");
            DBQuery.Criteria.AddCondition("type", ConditionOperator.Equal, 0); //dashboards
            DBQuery.Orders.Add(new OrderExpression("name", OrderType.Ascending));
            return service.RetrieveMultiple(DBQuery);
        }

        /// <summary>
        /// Get all the user's Dashboards
        /// </summary>
        /// <param name="domainName"></param>
        /// <returns></returns>
        public EntityCollection GetUserDashBoards()
        {
            QueryExpression DBQuery = new QueryExpression("userform");
            DBQuery.ColumnSet = new ColumnSet("name", "userformid");

            LinkEntity linkuser = new LinkEntity("userform", "systemuser", "ownerid", "systemuserid", JoinOperator.Inner);
            linkuser.EntityAlias = "user";
            linkuser.Columns = new ColumnSet("fullname");

            DBQuery.LinkEntities.Add(linkuser);

            return service.RetrieveMultiple(DBQuery);
        }

        public string UpdateUserSettings(List<Guid> usersId, Guid? dashboardId, bool UpdateHomePage, string WorkdayStartTime,
            string WorkdayStopTime, Guid? TransactionCurrencyId, int? PagingLimit, int? UILanguageId, int? TimeZoneCode, bool? IsSendAsAllowed = null,
            bool? IsStartedPanes = null, int? ReportScriptErrors = null, int? modeViewForm = null, int? modeAdvanceFind = null, object currentFormat = null,
            int? shortDateFormat = null, object dateFormatString = null, object dateSeparator = null, int? longDateFormat = null, int? timeFormat = null, object timeSeparator = null,
            int? currencyFormat = null, int? negativeCurFormat = null, object decimalSymbol = null, object groupingSymbol = null, object digitGroup = null,
            object negativeFormat = null)
        {
            string retMessage = "Finished Successfully";
            bool DataToUpdate = false;
            ExecuteMultipleRequest requestWithResults = new ExecuteMultipleRequest()
            {
                // Assign settings that define execution behavior: continue on error, return responses. 
                Settings = new ExecuteMultipleSettings()
                {
                    ContinueOnError = false,
                    ReturnResponses = true
                },
                // Create an empty organization request collection.
                Requests = new OrganizationRequestCollection()
            };

            foreach (Guid u in usersId)
            {
                Entity userSettings = new Entity("usersettings");
                userSettings.Id = u;
                if (dashboardId != null)
                {
                    DataToUpdate = true;
                    userSettings["defaultdashboardid"] = dashboardId;
                }
                if (UpdateHomePage == true)
                {
                    DataToUpdate = true;
                    userSettings["homepagearea"] = "Workplace";
                    userSettings["homepagesubarea"] = "nav_dashboards";
                }

                if (!string.IsNullOrEmpty(WorkdayStartTime) && !string.IsNullOrEmpty(WorkdayStopTime))
                {
                    DataToUpdate = true;
                    userSettings["workdaystarttime"] = WorkdayStartTime;
                    userSettings["workdaystoptime"] = WorkdayStopTime;
                }
                if (TransactionCurrencyId != null)
                {
                    DataToUpdate = true;
                    userSettings["transactioncurrencyid"] = new EntityReference("transactioncurrency", (Guid)TransactionCurrencyId);
                }
                if (PagingLimit != null)
                {
                    DataToUpdate = true;
                    userSettings["paginglimit"] = (int)PagingLimit;
                }
                if (UILanguageId != null)
                {
                    DataToUpdate = true;
                    userSettings["uilanguageid"] = (int)UILanguageId;
                }
                if (TimeZoneCode != null)
                {
                    DataToUpdate = true;
                    userSettings["timezonecode"] = (int)TimeZoneCode;
                }
                if (IsSendAsAllowed != null)
                {
                    DataToUpdate = true;
                    userSettings["issendasallowed"] = (bool)IsSendAsAllowed;
                }
                if (IsStartedPanes != null)
                {
                    DataToUpdate = true;
                    userSettings["getstartedpanecontentenabled"] = (bool)IsStartedPanes;
                }
                if (ReportScriptErrors != null)
                {
                    DataToUpdate = true;
                    userSettings["reportscripterrors"] = new OptionSetValue((int)ReportScriptErrors);
                }
                if (modeViewForm != null)
                {
                    DataToUpdate = true;
                    userSettings["entityformmode"] = new OptionSetValue((int)modeViewForm);
                }
                if (modeAdvanceFind != null)
                {
                    DataToUpdate = true;
                    userSettings["advancedfindstartupmode"] = (int)modeAdvanceFind;
                }
                if (currentFormat != null)
                {
                    DataToUpdate = true;
                    userSettings["localeid"] = currentFormat;
                }
                if (shortDateFormat != -1 && dateSeparator != null)
                {
                    DataToUpdate = true;
                    userSettings["dateseparator"] = dateSeparator.ToString();
                    userSettings["dateformatcode"] = (int)shortDateFormat;
                    userSettings["dateformatstring"] = dateFormatString.ToString();
                }
                if (longDateFormat != -1)
                {
                    DataToUpdate = true;
                    userSettings["longdateformatcode"] = longDateFormat;
                }
                if (timeFormat != -1 && timeSeparator != null)
                {
                    DataToUpdate = true;
                    userSettings["timeseparator"] = timeSeparator.ToString();
                    userSettings["timeformatcode"] = (int)timeFormat;
                }
                if (currencyFormat != -1)
                {
                    DataToUpdate = true;
                    userSettings["currencyformatcode"] = currencyFormat;
                }
                if (negativeCurFormat != -1)
                {
                    DataToUpdate = true;
                    userSettings["negativecurrencydormatcode"] = negativeCurFormat;
                }
                if (decimalSymbol != null)
                {
                    DataToUpdate = true;
                    userSettings["decimalsymbol"] = decimalSymbol.ToString();
                }
                if (groupingSymbol != null)
                {
                    DataToUpdate = true;
                    userSettings["numberseparator"] = groupingSymbol.ToString();
                }
                if (digitGroup != null)
                {
                    DataToUpdate = true;
                    userSettings["numbergroupformat"] = digitGroup.ToString();
                }
                if (negativeFormat != null)
                {
                    DataToUpdate = true;
                    userSettings["negativeformatcode"] = negativeFormat.ToString();
                }
                if (DataToUpdate == false)
                {
                    retMessage = "Did not select any update to do";
                    break;
                }

                UpdateRequest updateReq = new UpdateRequest();
                updateReq.Target = userSettings;
                requestWithResults.Requests.Add(updateReq);
            }

            if (DataToUpdate == true)
            {
                ExecuteMultipleResponse resp = (ExecuteMultipleResponse)service.Execute(requestWithResults);

                if (resp.IsFaulted == true)
                {
                    retMessage = "Finished with errors:" + Environment.NewLine;
                    for (int i = 0; i < resp.Responses.Count; i++)
                    {
                        if (resp.Responses[i].Fault != null)
                        {
                            retMessage += "Error in item Nr: " + (i + 1).ToString() + "-> " + resp.Responses[i].Fault.Message;
                        }
                    }
                }
            }
            return retMessage;
        }

        public string AssignDefaultTeam(Dictionary<Guid, Guid> userTeamDictionary)
        {
            string retMessage = "Finished Successfully";

            if (userTeamDictionary.Count > 0)
            {
                retMessage = "Finished Successfully";

                ExecuteMultipleRequest requestWithResults = new ExecuteMultipleRequest()
                {
                    // Assign settings that define execution behavior: continue on error, return responses. 
                    Settings = new ExecuteMultipleSettings()
                    {
                        ContinueOnError = false,
                        ReturnResponses = true
                    },
                    // Create an empty organization request collection.
                    Requests = new OrganizationRequestCollection()
                };

                foreach (var item in userTeamDictionary)
                {
                    Entity user = new Entity("systemuser");
                    user.Id = item.Key;
                    user["new_id_related_team"] = new EntityReference("team", item.Value);

                    UpdateRequest updateReq = new UpdateRequest();
                    updateReq.Target = user;
                    requestWithResults.Requests.Add(updateReq);

                }

                ExecuteMultipleResponse resp = (ExecuteMultipleResponse)service.Execute(requestWithResults);

                if (resp.IsFaulted == true)
                {
                    retMessage = "Finished with errors:" + Environment.NewLine;
                    for (int i = 0; i < resp.Responses.Count; i++)
                    {
                        if (resp.Responses[i].Fault != null)
                        {
                            retMessage += "Error in item Nr: " + (i + 1).ToString() + "-> " + resp.Responses[i].Fault.Message;
                        }
                    }
                }
            }
            else
            {
                retMessage = "No user had been updated";
            }
            return retMessage;
        }

        /// <summary>
        ///  Open a recotd in the CRM
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="recordType"></param>
        public void OpenWithArguments(string recordId, string recordType)
        {
            if (recordId != string.Empty && recordType != string.Empty)
            {
                string crmPath = url.Substring(0, url.IndexOf("XRMServices")) + "main.aspx?etn=" + recordType + "&pagetype=entityrecord&id=%7B" + recordId + "%7D";
                Process.Start("IExplore.exe", crmPath);
            }
        }

        public EntityCollection GetSystemCurrencies()
        {

            QueryExpression query = new QueryExpression("transactioncurrency");
            query.ColumnSet = new ColumnSet("transactioncurrencyid", "currencyname", "currencysymbol");

            return service.RetrieveMultiple(query);
        }

        public int[] GetSystemLanguages()
        {

            RetrieveAvailableLanguagesRequest req = new RetrieveAvailableLanguagesRequest();
            RetrieveAvailableLanguagesResponse resp = (RetrieveAvailableLanguagesResponse)service.Execute(req);


            if (resp.Results.Count() > 0)
            {
                return ((int[])(resp.Results["LocaleIds"]));
            }
            else
            {
                return null;
            }
        }

        public EntityCollection GetSystemsTimeZones()
        {
            QueryExpression query = new QueryExpression("timezonedefinition");
            query.ColumnSet = new ColumnSet("timezonecode", "timezonedefinitionid", "userinterfacename");
            query.Orders.Add(new OrderExpression("userinterfacename", OrderType.Ascending));

            return service.RetrieveMultiple(query);
        }

        public Image GetImage(string imageName)
        {
            Image ImgToRet;
            ImgToRet = Image.FromFile(ResourcesPath + "\\" + imageName);
            return ImgToRet;
        }

        public Image GetImage(int? privilegedepthmask = null)
        {
            Image ImgToRet;

            switch (privilegedepthmask)
            {
                case 1:
                    if (userImage == null)
                    {
                        userImage = Image.FromFile(ResourcesPath + "\\User.gif");
                    }
                    ImgToRet = userImage;
                    break;
                case 2:
                    if (BUImage == null)
                    {
                        BUImage = Image.FromFile(ResourcesPath + "\\BusinessUnit.gif");
                    }
                    ImgToRet = BUImage;
                    break;
                case 4:
                    if (parentImage == null)
                    {
                        parentImage = Image.FromFile(ResourcesPath + "\\Parent.gif");
                    }
                    ImgToRet = parentImage;
                    break;
                case 8:
                    if (orgImage == null)
                    {
                        orgImage = Image.FromFile(ResourcesPath + "\\Organization.gif");
                    }
                    ImgToRet = orgImage;
                    break;
                default:
                    if (noneImage == null)
                    {
                        noneImage = Image.FromFile(ResourcesPath + "\\None.gif");
                    }
                    ImgToRet = noneImage;
                    break;
            }
            return ImgToRet;
        }

        public int GetDepthByImage(string imageTag)
        {
            int depth;
            int.TryParse(imageTag, out depth);
            return depth;
        }

        public Entity GetOrganizationSettings()
        {
            Entity organizationSettings = null;

            QueryExpression query = new QueryExpression("organization");
            query.ColumnSet = new ColumnSet("currencysymbol", "dateseparator", "timeseparator", "decimalsymbol", "numberseparator", "numbergroupformat");

            EntityCollection allOrg = service.RetrieveMultiple(query);

            if (allOrg.Entities.Count() > 0)
            {
                organizationSettings = allOrg.Entities[0];
            }

            return organizationSettings;
        }

        public void ChangeRecordState(string entityName, Guid id, int statecode, int statuscode)
        {
            SetStateRequest state = new SetStateRequest();

            // Set the Request Object's Properties
            state.State = new OptionSetValue(statecode);
            state.Status =
                new OptionSetValue(statuscode);

            // Point the Request to the case whose state is being changed
            state.EntityMoniker = new EntityReference(entityName, id);

            // Execute the Request
            SetStateResponse stateSet = (SetStateResponse)service.Execute(state);
        }

        public void GetStateCodesForEntity()
        {

        }

        public RetrieveAttributeResponse GetAttributeMetadata(string entityName, string fieldName)
        {
            RetrieveAttributeRequest attributeRequest = new RetrieveAttributeRequest
            {
                EntityLogicalName = entityName,
                LogicalName = fieldName,
                RetrieveAsIfPublished = true
            };

            // Execute the request
            return (RetrieveAttributeResponse)service.Execute(attributeRequest);
        }
    }
}
