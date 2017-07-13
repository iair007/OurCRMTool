using System;
using System.Net;
using System.ServiceModel.Description;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System.Security;


namespace OurCRMTool
{
    public class CRMHelpper
    {
        log4net.ILog log;

        public CRMHelpper(log4net.ILog _log)
        {
            log = _log;
        }
        public IOrganizationService GetCRMService(string url, string dom, string user, string pass)
        {
            try
            {
                OrganizationServiceProxy proxy;
                IOrganizationService service;
                string uri = url;
                string userName = user;
                string password = pass;
                string domain = dom;

                IServiceConfiguration<IOrganizationService> config = ServiceConfigurationFactory.CreateConfiguration<IOrganizationService>(new Uri(uri));

                if (config.AuthenticationType == AuthenticationProviderType.Federation)
                {
                    // ADFS (IFD) Authentication
                    ClientCredentials clientCred = new ClientCredentials();
                    clientCred.UserName.UserName = userName;
                    clientCred.UserName.Password = password;
                    proxy = new OrganizationServiceProxy(config, clientCred);
                }
                else
                {
                    // On-Premise, non-IFD authentication
                    ClientCredentials credentials = new ClientCredentials();
                    credentials.Windows.ClientCredential = new NetworkCredential(userName, password, domain);
                    proxy = new OrganizationServiceProxy(new Uri(uri), null, credentials, null);
                }

                proxy.EnableProxyTypes();
                proxy.Timeout = new TimeSpan(0, 15, 0);

                service = (IOrganizationService)proxy;

                //check if the connection was successfull
                WhoAmIRequest request = new WhoAmIRequest();
                WhoAmIResponse response = (WhoAmIResponse)service.Execute(request);
                Guid userId = response.UserId;

                return service;
            }
            catch (Exception ex)
            {
                log.Error("GetCRMService: " + ex.Message);
                return null;
            }
        }

        public IOrganizationService GetCRMService(string url)
        {
            try
            {
                OrganizationServiceProxy proxy;
                IOrganizationService service;
                string uri = url;

                IServiceConfiguration<IOrganizationService> config = ServiceConfigurationFactory.CreateConfiguration<IOrganizationService>(new Uri(uri));

                ClientCredentials credentials = new ClientCredentials();
                credentials.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;
                proxy = new OrganizationServiceProxy(new Uri(uri), null, credentials, null);

                proxy.EnableProxyTypes();
                proxy.Timeout = new TimeSpan(0, 15, 0);

                service = (IOrganizationService)proxy;

                //check if the connection was successfull
                WhoAmIRequest request = new WhoAmIRequest();
                WhoAmIResponse response = (WhoAmIResponse)service.Execute(request);
                Guid userId = response.UserId;

                return service;
            }
            catch (Exception ex)
            {
                log.Error("GetCRMService: " + ex.Message);
                return null;
            }
        }

        public IOrganizationService GetCRMServiceOnline(string UserName, string Password, string SoapOrgServiceUri)
        {
            try
            {
                ClientCredentials credentials = new ClientCredentials();
                credentials.UserName.UserName = UserName;
                credentials.UserName.Password = Password;
                Uri serviceUri = new Uri(SoapOrgServiceUri);
                OrganizationServiceProxy proxy = new OrganizationServiceProxy(serviceUri, null, credentials, null);
                proxy.EnableProxyTypes();
                IOrganizationService service = (IOrganizationService)proxy;

                //check if the connection was successfull
                WhoAmIRequest request = new WhoAmIRequest();
                WhoAmIResponse response = (WhoAmIResponse)service.Execute(request);
                Guid userId = response.UserId;

                return service;
            }
            catch (Exception ex)
            {
                log.Error("GetCRMServiceOnline: " + ex.Message);
                return null;
            }
        }
    }
}
