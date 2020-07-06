using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace mdatp_pwsh
{
    public class DatpMachineTagPost
    {
        public string Value { get; set; }
        public string Action { get; set; }
    }

    public class DatpMachineScanPost
    {
        public string Comment { get; set; }

        public string ScanType { get; set; }
    }

    //Alert Objects
    public class DatpAlert
    {
        [JsonProperty("id")]
        public string AlertId { get; set; }

        [JsonProperty("alertCreationTime")]
        public Nullable<DateTime> AlertCreationTime { get; set; }

        [JsonProperty("title")]
        public string AlertTitle { get; set; }

        [JsonProperty("description")]
        public string AlertDescription { get; set; }

        [JsonProperty("incidentId")]
        public Int64 IncidentId { get; set; }

        [JsonProperty("firstEventTime")]
        public Nullable<DateTime> FirstEventTime { get; set; }

        [JsonProperty("lastEventTime")]
        public Nullable<DateTime> LastEventTime { get; set; }

        [JsonProperty("resolvedTime")]
        public Nullable<DateTime> ResolvedTime { get; set; }

        [JsonProperty("machineId")]
        public string MachineId { get; set; }

        [JsonProperty("assignedTo")]
        public string AssignedTo { get; set; }

        [JsonProperty("severity")]
        public string Severity { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("classification")]
        public string Classification { get; set; }

        [JsonProperty("determination")]
        public string Determination { get; set; }

        [JsonProperty("investigationState")]
        public string InvestigationState { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("detectionSource")]
        public string DetectionSource { get; set; }

        [JsonProperty("threatFamilyName")]
        public string ThreatFamilyName { get; set; }

    }

    public class DatpAlertCollection
    {
        public List<DatpAlert> value { get; set; }
    }

    //User Objects
    public class DatpUser
    {
        [JsonProperty("id")]
        public string UserId { get; set; }

        [JsonProperty("firstSeen")]
        public Nullable<DateTime> FirstSeen { get; set; }

        [JsonProperty("lastSeen")]
        public Nullable<DateTime> LastSeen { get; set; }

        [JsonProperty("mostPrevalentMachineId")]
        public string MostPrevalentMachineId { get; set; }

        [JsonProperty("leastPrevalentMachineId")]
        public string LeastPrevalentMachineId { get; set; }

        [JsonProperty("logonTypes")]
        public string LogonTypes { get; set; }

        [JsonProperty("logonMachinesCount")]
        public Int64 LogonMachinesCount { get; set; }

        [JsonProperty("isDomainAdmin")]
        public Boolean IsDomainAdmin { get; set; }

        [JsonProperty("isOnlyNetworkUser")]
        public Nullable<Boolean> IsOnlyNetworkUser { get; set; }
    }

    public class DatpUserCollection
    {
        [JsonProperty("value")]
        public List<DatpUser> value { get; set; }
    }

    //File Objects
    public class DatpFile
    {
        [JsonProperty("fileProductName")]
        public string FileProductName { get; set; }

        [JsonProperty("filePublisher")]
        public string FilePublisher { get; set; }

        [JsonProperty("sha1")]
        public string SHA1 { get; set; }

        [JsonProperty("sha256")]
        public string SHA256 { get; set; }

        [JsonProperty("md5")]
        public string MD5 { get; set; }

        [JsonProperty("size")]
        public Int64 FileSize { get; set; }

        [JsonProperty("fileType")]
        public string FileType { get; set; }

        [JsonProperty("isPeFile")]
        public Boolean IsPeFile { get; set; }

        [JsonProperty("globalPrevalence")]
        public Int64 GlobalPrevalence { get; set; }

        [JsonProperty("globalFirstObserved")]
        public DateTime GlobalFirstObserved { get; set; }

        [JsonProperty("globalLastObserved")]
        public DateTime GlobalLastObserved { get; set; }

        [JsonProperty("signer")]
        public string Signer { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("signerHash")]
        public string SignerHash { get; set; }

        [JsonProperty("isValidCertificate")]
        public Boolean IsValidCertificate { get; set; }
    }

    //IP Address Objects
    public class DatpIpAddress
    {
        [JsonProperty("ipAddress")]
        public string IpAddress { get; set; }

        [JsonProperty("orgPrevalence")]
        public Int64 Prevalence { get; set; }

        [JsonProperty("orgFirstSeen")]
        public DateTime FirstSeen { get; set; }

        [JsonProperty("orgLastSeen")]
        public DateTime LastSeen { get; set; }
    }

    //Indicator Objects
    public class DatpIndicator
    {
        [JsonProperty("title")]
        public string IndicatorTitle { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("indicatorValue")]
        public string IndicatorValue { get; set; }

        [JsonProperty("indicatorType")]
        public Enum IndicatorType { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("severity")]
        public string Severity { get; set; }

        [JsonProperty("recommendedActions")]
        public string RecommendedActions { get; set; }

        [JsonProperty("creationTimeDateTimeUtc")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("expirationTime")]
        public DateTime ExpirationTime { get; set; }

        [JsonProperty("rbacGroupNames")]
        public string[] RbacGroupNames { get; set; }
    }

    //Isolate Objects
    public class DatpIsolatePost
    {
        public string Comment { get; set; }
        public string IsolationType { get; set; }
    }

    public class DatpUnIsolatePost
    {
        public string Comment { get; set; }
    }

    //Domain Objects
    public class DatpDomainStats
    {
        [JsonProperty("host")]
        public string DomainHost { get; set; }

        [JsonProperty("orgPrevalence")]
        public Nullable<Int64> OrgPrevalence { get; set; }

        [JsonProperty("orgFirstSeen")]
        public Nullable<DateTime> OrgFirstSeen { get; set; }

        [JsonProperty("orgLastSeen")]
        public Nullable<DateTime> OrgLastSeen { get; set; }
    }

    public class DatpCollectInvestPkgPost
    {
        public string Comment { get; set; }
    }
    public class DatpActivityResponse
    {
        [JsonProperty("id")]
        public string ActivityId { get; set; }

        [JsonProperty("type")]
        public string ActivityType { get; set; }

        [JsonProperty("requestor")]
        public string Requestor { get; set; }

        [JsonProperty("requestorcomment")]
        public string RequestorComment { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("machineId")]
        public string MachineId { get; set; }

        [JsonProperty("creationDateTimeUtc")]
        public Nullable<DateTime> CreationDateTimeUtc { get; set; }

        [JsonProperty("lastUpdateTimeUtc")]
        public Nullable<DateTime> LastUpdateTimeUtc { get; set; }

        [JsonProperty("relatedFileInfo")]
        public DatpFileIdentifier RelatedFileInfo { get; set; }

    }

    public class DatpActivityResponseCollection
    {
        public List<DatpActivityResponse> value { get; set; }
    }

    public class DatpFileIdentifier
    {
        [JsonProperty("fileIdentifier")]
        public string FileIdentifier { get; set; }

        [JsonProperty("fileIdentifierType")]
        public string FileIdentifierType { get; set; }
    }

    public class DatpError
    {
        public DatpErrorDetails error { get; set; }
    }

    public class DatpErrorDetails
    {
        public string code { get; set; }
        public string message { get; set; }
    }

    public class DatpModuleConfig
    {
        public string PublicClientAppId { get; set; }
        public string TenantId { get; set; }
    }
}