
namespace XdsKit.Oasis.RegRep
{
    public class AssociationType : UriEnumeration
    {
        protected AssociationType(string uri)
            : base(uri)
        { }

        public static AssociationType AffiliatedWith =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:AffiliatedWith");

        public static AssociationType EmployeeOf =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:AffiliatedWith:EmployeeOf");

        public static AssociationType MemberOf =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:AffiliatedWith:MemberOf");

        public static AssociationType Annotates =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:Annotates");

        public static AssociationType Presents =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:Presents");

        public static AssociationType Supports =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:Supports");

        public static AssociationType DescribedBy =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:DescribedBy");

        public static AssociationType OperatesOn =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:OperatesOn");

        public static AssociationType RelatedTo =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:RelatedTo");

        public static AssociationType SourceOf =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:SourceOf");

        public static AssociationType HasCatalogedMetadata =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:HasCatalogedMetadata");

        public static AssociationType HasFederationMember =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:HasFederationMember");

        public static AssociationType HasMember =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:HasMember");

        public static AssociationType HasComment =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:HasComment");

        public static AssociationType HasRole =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:HasRole");

        public static AssociationType HasSubmittingOrganization =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:HasSubmittingOrganization");

        public static AssociationType HasParent =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:HasParent");

        public static AssociationType ExternallyLinks =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:ExternallyLinks");

        public static AssociationType Contains =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:Contains");

        public static AssociationType EquivalentTo =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:EquivalentTo");

        public static AssociationType Extends =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:Extends");

        public static AssociationType Implements =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:Implements");

        public static AssociationType Imports =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:Imports");

        public static AssociationType Includes =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:Includes");

        public static AssociationType InstanceOf =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:InstanceOf");

        public static AssociationType Supersedes =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:Supersedes");

        public static AssociationType Uses = 
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:Uses");

        public static AssociationType Replaces =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:Replaces");

        public static AssociationType SubmitterOf =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:SubmitterOf");

        public static AssociationType ResponsibleFor =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:ResponsibleFor");

        public static AssociationType OwnerOf =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:OwnerOf");

        public static AssociationType OffersService =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:OffersService");

        public static AssociationType ContentManagementServiceFor =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:ContentManagementServiceFor");

        public static AssociationType InvocationControlFileFor =
            new AssociationType("urn:oasis:names:tc:ebxml-regrep:AssociationType:InvocationControlFileFor");

        public static AssociationType CatalogingControlFileFor =
            new AssociationType(
                "urn:oasis:names:tc:ebxml-regrep:AssociationType:InvocationControlFileFor:CatalogingControlFileFor");

        public static AssociationType ValidationControlFileFor =
            new AssociationType(
                "urn:oasis:names:tc:ebxml-regrep:AssociationType:InvocationControlFileFor:ValidationControlFileFor");

        public static AssociationType FilteringControlFileFor =
            new AssociationType(
                "urn:oasis:names:tc:ebxml-regrep:AssociationType:InvocationControlFileFor:FilteringControlFileFor");
    }
}
