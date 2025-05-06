using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobTriggerTest
{

    public class BlobItemInfo
    {
        public DateTime LastModified { get; set; }
        public DateTime CreatedOn { get; set; }
        public Metadata Metadata { get; set; }
        public object ObjectReplicationDestinationPolicyId { get; set; }
        public object ObjectReplicationSourceProperties { get; set; }
        public int BlobType { get; set; }
        public DateTime CopyCompletedOn { get; set; }
        public object CopyStatusDescription { get; set; }
        public object CopyId { get; set; }
        public object CopyProgress { get; set; }
        public object CopySource { get; set; }
        public int CopyStatus { get; set; }
        public object BlobCopyStatus { get; set; }
        public bool IsIncrementalCopy { get; set; }
        public object DestinationSnapshot { get; set; }
        public int LeaseDuration { get; set; }
        public int LeaseState { get; set; }
        public int LeaseStatus { get; set; }
        public int ContentLength { get; set; }
        public string ContentType { get; set; }
        public Etag ETag { get; set; }
        public string ContentHash { get; set; }
        public object ContentEncoding { get; set; }
        public object ContentDisposition { get; set; }
        public object ContentLanguage { get; set; }
        public object CacheControl { get; set; }
        public int BlobSequenceNumber { get; set; }
        public string AcceptRanges { get; set; }
        public int BlobCommittedBlockCount { get; set; }
        public bool IsServerEncrypted { get; set; }
        public object EncryptionKeySha256 { get; set; }
        public object EncryptionScope { get; set; }
        public string AccessTier { get; set; }
        public bool AccessTierInferred { get; set; }
        public object ArchiveStatus { get; set; }
        public DateTime AccessTierChangedOn { get; set; }
        public object VersionId { get; set; }
        public bool IsLatestVersion { get; set; }
        public int TagCount { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool IsSealed { get; set; }
        public object RehydratePriority { get; set; }
        public DateTime LastAccessed { get; set; }
        public Immutabilitypolicy ImmutabilityPolicy { get; set; }
        public bool HasLegalHold { get; set; }
    }

    public class Metadata
    {
    }

    public class Etag
    {
    }

    public class Immutabilitypolicy
    {
        public object ExpiresOn { get; set; }
        public object PolicyMode { get; set; }
    }

}