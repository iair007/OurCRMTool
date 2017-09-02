using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm.Sdk.Messages;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System.Diagnostics;
using System.Data;

namespace OurCRMTool
{
    public class BL2Enviroments
    {
        IOrganizationService service1 = null;
        IOrganizationService service2 = null;
        public LogUtils log;
        public string url1;
        public string url2;

        public BL2Enviroments(IOrganizationService _service1, IOrganizationService _service2, string _url1, string _url2)
        {
            service1 = _service1;
            service2 = _service2;
            url1 = _url1;
            url2 = _url2;
        }

        /// <summary>
        /// retrieve all the records from an enviroment with the selectedFields 
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="compareFieldsList"></param>
        /// <param name="selectFields"></param>
        /// <param name="orderby"></param>
        /// <param name="direcction"></param>
        /// <param name="fromEnviroment1"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public EntityCollection GetRecords(string entityName, Dictionary<string, string> compareFieldsList, Dictionary<string, string> selectFields, Dictionary<string, string> recordKeyList, string orderby, OrderType direcction, bool fromEnviroment1, string top = "")
        {
            int pageNumber = 1;
            EntityCollection records = new EntityCollection();
            IOrganizationService service = fromEnviroment1 ? service1 : service2;

            List<string> allColumnsNeeded = selectFields.Keys.Union(compareFieldsList.Keys).ToList();
            allColumnsNeeded = allColumnsNeeded.Union(recordKeyList.Keys).ToList();

            QueryExpression query = new QueryExpression(entityName);
            query.ColumnSet = new ColumnSet(allColumnsNeeded.ToArray());
            query.Orders.Add(new OrderExpression(orderby, direcction));

            query.PageInfo = new PagingInfo();
            query.PageInfo.PageNumber = pageNumber;
            query.PageInfo.PagingCookie = null;
            if (top != "")
            {
                query.PageInfo.Count = int.Parse(top);
            }

            while (true)
            {
                // Retrieve the page.
                EntityCollection results = service.RetrieveMultiple(query);
                if (results.Entities != null)
                {
                    records.Entities.AddRange(results.Entities);
                }

                // Check for more records, if it returns true.
                if (results.MoreRecords && (top == "" || results.Entities.Count < int.Parse(top)))
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
            return records;
        }

        public void WriteTxtLog(string newLine, LogUtils log, TextBox txtLog = null)
        {
            if (txtLog != null)
            {
                string message = txtLog.Text + Environment.NewLine + "- " + DateTime.Now + "- " + newLine;
                txtLog.Text = message;

            }
            if (log != null)
            {
                log.WriteToLog(newLine);
            }
        }

        public RetrieveAllEntitiesResponse GetEntities(bool fromService1 = true)
        {
            RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest()
            {
                EntityFilters = EntityFilters.Entity,
                // EntityFilters = EntityFilters.Attributes,
                RetrieveAsIfPublished = true
            };

            // Retrieve the MetaData.
            RetrieveAllEntitiesResponse resp;
            if (fromService1)
                resp = (RetrieveAllEntitiesResponse)service1.Execute(request);
            else
                resp = (RetrieveAllEntitiesResponse)service2.Execute(request);

            return resp;
        }

        /// <summary>
        ///  Open a recotd in the CRM
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="recordType"></param>
        public void OpenWithArguments(string recordId, string recordType, bool fromEnviroment1)
        {
            if (recordId != string.Empty && recordType != string.Empty)
            {
                string url = fromEnviroment1 ? url1 : url2;
                string crmPath = url.Substring(0, url.IndexOf("XRMServices")) + "main.aspx?etn=" + recordType + "&pagetype=entityrecord&id=%7B" + recordId + "%7D";
                Process.Start("IExplore.exe", crmPath);
            }
        }

        /// <summary>
        /// Get the fields in an entity
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public RetrieveEntityResponse GetEntityFields(string entityName)
        {
            RetrieveEntityRequest request = new RetrieveEntityRequest()
            {
                EntityFilters = EntityFilters.Attributes,
                LogicalName = entityName,
                RetrieveAsIfPublished = true
            };

            // Retrieve the MetaData.
            RetrieveEntityResponse resp;
            resp = (RetrieveEntityResponse)service1.Execute(request);

            return resp;
        }

        /// <summary>
        /// Get all selected record's column, to create a equal record in the other enviroment
        /// </summary>
        /// <param name="fromService1"></param>
        /// <param name="entityName"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public EntityCollection GetAllColumnsForRecords(bool fromService1, string entityName, bool isActivity, List<Guid> recordsGuids, Dictionary<string, string> selectFields)
        {
            EntityCollection allRecords = new EntityCollection();
            if (selectFields != null && selectFields.Count() > 0)
            {
                IOrganizationService service = fromService1 ? service1 : service2;
                int pageNumber = 1;

                ColumnSet columns = new ColumnSet();

                foreach (string fieldName in selectFields.Keys)
                {
                    columns.AddColumn(fieldName.ToLower());
                }

                QueryExpression query = new QueryExpression(entityName);
                query.ColumnSet = columns;
                if (isActivity)
                {
                    query.Criteria.AddCondition(new ConditionExpression("activityid", ConditionOperator.In, recordsGuids));
                }
                else
                {
                    query.Criteria.AddCondition(new ConditionExpression(entityName + "id", ConditionOperator.In, recordsGuids));
                }
                query.PageInfo = new PagingInfo();
                query.PageInfo.PageNumber = pageNumber;
                query.PageInfo.PagingCookie = null;

                while (true)
                {
                    // Retrieve the page.
                    EntityCollection results = service.RetrieveMultiple(query);
                    if (results.Entities != null)
                    {
                        allRecords.Entities.AddRange(results.Entities);
                    }
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
            }
            return allRecords;
        }

        /// <summary>
        /// Retreive all the records that want to update in the other environmnent with the coresponding fields
        /// </summary>
        /// <param name="fromService1"></param>
        /// <param name="entityName"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public Dictionary<Guid, Entity> GetAllRecordsToUpdate(bool fromService1, string entityName, Dictionary<Guid, Entity> recordsToUpdate, Dictionary<string, string> selectFields)
        {
            Dictionary<Guid, Entity> ret = new Dictionary<Guid, Entity>();
            if (recordsToUpdate.Count() > 0 && selectFields != null && selectFields.Count() > 0)
            {
                IOrganizationService service = fromService1 ? service1 : service2;

                ColumnSet columns = new ColumnSet();

                foreach (string fieldName in selectFields.Keys)
                {
                    columns.AddColumn(fieldName.ToLower());
                }

                foreach (KeyValuePair<Guid, Entity> r in recordsToUpdate)
                {
                    QueryExpression query = new QueryExpression(entityName);
                    query.ColumnSet = columns;
                    query.Criteria.AddCondition(new ConditionExpression(entityName + "id", ConditionOperator.Equal, r.Value.Id));

                    EntityCollection results = service.RetrieveMultiple(query);
                    if (results.Entities.Count() > 0)
                    {
                        ret.Add(r.Key, results.Entities[0]);
                    }
                }
            }

            return ret;
        }


        public string UpdateRecordInEnviroment(bool fromEnviroment1To2, Dictionary<Guid, Entity> recordsToUpdate, string entityName, Dictionary<string, string> selectFields, ref bool closeFormWhenFinish, ref List<EntityReference> recordsToOpen)
        {
            string message = string.Empty;
            int maxBatchSize = 1000;
            int errors = 0;
            IOrganizationService service = fromEnviroment1To2 ? service2 : service1;
            ExecuteMultipleRequest requestWithResults = new ExecuteMultipleRequest()
            {
                // Assign settings that define execution behavior: continue on error, return responses. 
                Settings = new ExecuteMultipleSettings()
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                },
                // Create an empty organization request collection.
                Requests = new OrganizationRequestCollection()
            };

            foreach (KeyValuePair<Guid, Entity> r in recordsToUpdate)
            {
                Entity recotordToUpdate = new Entity(entityName);
                recotordToUpdate.Id = r.Key;

                foreach (KeyValuePair<string, object> a in r.Value.Attributes)
                {
                    if (a.Key != "Id" && a.Key != entityName + "id")
                    {
                        recotordToUpdate[a.Key] = a.Value;
                    }
                }

                //foreach (DataGridViewCell cell in r.Value)
                //{

                // //Only update values that are no EntityReference
                //  if (selectFields.Keys.Contains(cell.OwningColumn.Name))
                ////            && selectFields[cell.OwningColumn.Name] != "entityreference"
                ////            && selectFields[cell.OwningColumn.Name] != "lookup"
                ////            && selectFields[cell.OwningColumn.Name] != "owner")
                // {
                ////if is one of the column that the user is seen, update it in the other enviroment
                //     recotordToUpdate[cell.OwningColumn.Name] = ConvertToObject(cell.Value.ToString(), selectFields[cell.OwningColumn.Name]);
                // }
                // }

                UpdateRequest updateRequest = new UpdateRequest { Target = recotordToUpdate };
                requestWithResults.Requests.Add(updateRequest);

                if (requestWithResults.Requests.Count() == maxBatchSize || r.Value == recordsToUpdate.Last().Value)   //start updateing when maxBatchSize records is reach or when got to last record
                {
                    ExecuteMultipleResponse responseWithResults = (ExecuteMultipleResponse)service.Execute(requestWithResults);

                    //  Display the results returned in the responses.
                    if (responseWithResults.IsFaulted == true)
                    {
                        message = "Finished Updateing with errors:" + Environment.NewLine;
                        errors += responseWithResults.Responses.Count;
                        for (int i = 0; i < responseWithResults.Responses.Count; i++)
                        {
                            if (responseWithResults.Responses[i].Fault != null)
                            {
                                WriteTxtLog("Error when Updating record: " + responseWithResults.Responses[i].RequestIndex + " Error: " + responseWithResults.Responses[i].Fault.Message, log);
                                message += "Error when Updating record: " + responseWithResults.Responses[i].RequestIndex + " Error: " + responseWithResults.Responses[i].Fault.Message + Environment.NewLine;
                            }
                        }
                    }
                    else {
                        foreach (KeyValuePair<Guid, Entity> re in recordsToUpdate)
                        {
                            EntityReference rec = new EntityReference(entityName, re.Key);
                            recordsToOpen.Add(rec);
                        }
                    }
                    requestWithResults.Requests.Clear();
                }
            }

            message += Environment.NewLine + "Updated " + (recordsToUpdate.Count() - errors).ToString() + " from " + recordsToUpdate.Count().ToString();

            return message;
        }

        public string CreateRecordInEnviroment(bool inEnviroment2, EntityCollection recordsCol, string entityName, ref bool closeFormWhenFinish, ref List<EntityReference> recordsToOpen)
        {
            string message = string.Empty;
            int maxBatchSize = 1000;
            int errors = 0;
            IOrganizationService service = inEnviroment2 ? service2 : service1;
            ExecuteMultipleRequest requestWithResults = new ExecuteMultipleRequest()
            {
                // Assign settings that define execution behavior: continue on error, return responses. 
                Settings = new ExecuteMultipleSettings()
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                },
                // Create an empty organization request collection.
                Requests = new OrganizationRequestCollection()
            };

            foreach (Entity e in recordsCol.Entities)
            {
                CreateRequest createRequest = new CreateRequest { Target = e };
                requestWithResults.Requests.Add(createRequest);

                if (requestWithResults.Requests.Count() == maxBatchSize || recordsCol.Entities.IndexOf(e) == recordsCol.Entities.Count() - 1)   //start updateing when maxBatchSize records is reach
                {
                    ExecuteMultipleResponse responseWithResults = (ExecuteMultipleResponse)service.Execute(requestWithResults);
                    WriteTxtLog("Test writing log", log);
                    //  Display the results returned in the responses.
                    if (responseWithResults.IsFaulted == true)
                    {
                        message = "Finished with errors:" + Environment.NewLine;
                        errors += responseWithResults.Responses.Count;
                        closeFormWhenFinish = false;
                        for (int i = 0; i < responseWithResults.Responses.Count; i++)
                        {
                            if (responseWithResults.Responses[i].Fault != null)
                            {
                                WriteTxtLog("Error when creating record: " + responseWithResults.Responses[i].RequestIndex + " Error: " + responseWithResults.Responses[i].Fault.Message, log);
                                message += "Error when creating record: " + responseWithResults.Responses[i].RequestIndex + " Error: " + responseWithResults.Responses[i].Fault.Message + Environment.NewLine;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < responseWithResults.Responses.Count; i++)
                        {
                            recordsToOpen.Add(new EntityReference(entityName, new Guid(responseWithResults.Responses[i].Response["id"].ToString())));
                        }
                    }
                    requestWithResults.Requests.Clear();
                }
            }
            message += Environment.NewLine + "Created " + (recordsCol.Entities.Count() - errors).ToString() + " from " + recordsCol.Entities.Count().ToString();
            return message;
        }

        /// <summary>
        /// will get the value and convert it to the corresponding object 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        private object ConvertToObject(string value, string attributeType)
        {
            object valueAsCorrespondingObject;

            switch (attributeType.ToLower())
            {
                case "string":
                    valueAsCorrespondingObject = value.ToString();
                    break;
                case "integer":
                    valueAsCorrespondingObject = int.Parse(value);
                    break;
                case "optionset":
                    valueAsCorrespondingObject = new OptionSetValue(int.Parse(value));
                    break;
                case "Status":
                    valueAsCorrespondingObject = new OptionSetValue(int.Parse(value));
                    break;
                case "state":
                    valueAsCorrespondingObject = new OptionSetValue(int.Parse(value));
                    break;
                case "Money":
                    valueAsCorrespondingObject = new Money(decimal.Parse(value));
                    break;
                case "decimal":
                    valueAsCorrespondingObject = decimal.Parse(value);
                    break;
                case "double":
                    valueAsCorrespondingObject = double.Parse(value);
                    break;
                case "picklist":
                    valueAsCorrespondingObject = new OptionSetValue(int.Parse(value));
                    break;
                case "boolean":
                    valueAsCorrespondingObject = bool.Parse(value);
                    break;
                case "datetime":
                    valueAsCorrespondingObject = DateTime.Parse(value);
                    break;
                default:
                    valueAsCorrespondingObject = value.ToString();
                    break;
            }

            return valueAsCorrespondingObject;
        }
    }
}
