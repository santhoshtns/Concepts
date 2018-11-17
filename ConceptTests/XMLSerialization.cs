using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace ConceptTests
{
    public static class XMLSerialization
    {
        public static object Deserialize<T>(string xmlConfig)
        {
            if (string.IsNullOrEmpty(xmlConfig)) return null;

            try
            {
                using (TextReader reader = new StringReader(xmlConfig))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Package GetPackageObject(string xmlConfig)
        {
            return (Package)Deserialize<Package>(xmlConfig);
        }

        public static Benefit GetBenefitObject(string xmlConfig)
        {
            return (Benefit)Deserialize<Benefit>(xmlConfig);
        }

        public static string GetXml(object o)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            catch (Exception ex)
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }
    }

    [Serializable, XmlRoot(ElementName = "Package"), XmlType("Package")]
    public class Package
    {
        [Serializable, XmlType("Benefits")]
        public class Benefits
        {
            [XmlElement("Benefit")]
            public List<BenefitInfo> BenefitInfos { get; set; }
        }

        [Serializable, XmlType("Benefit")]
        public class BenefitInfo
        {
            [XmlAttribute("ID")]
            public string Id { get; set; }

            [XmlAttribute("OptionId")]
            public string OptionId { get; set; }
        }

        [XmlElement("ID")]
        public string Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        [XmlElement("Price")]
        public int Price => CalculatePrice();

        private int CalculatePrice()
        {
            return 1;//ToDo
        }

        [XmlElement("Benefits")]
        public Benefits BenefitSelections { get; set; }
    }

    [XmlRoot(ElementName = "Benefit")]
    public class Benefit
    {
        public enum RatesMethod
        {
            MemberType,
            AllMemberSamePrice,
            MemberAge,
            RuleBased
        }

        public enum PriceMethod
        {
            PerMember,
            Group
        }

        public enum MemberType
        {
            Employee,
            Dependant,
            AllMembers
        }

        public const string SumAssuredCustomAmountToken = "$[SumAssured]";

        [XmlAttribute("ID")]
        public string Id { get; set; }

        [XmlAttribute("Type")]
        public string Type { get; set; }

        [XmlElement("Info")]
        public InfoDetails Info { get; set; }

        [XmlElement("PlansOrOptions")]
        public PlansOrOptionsDetails PlansOrOptions { get; set; }

        //[NotMapped]
        public int SortOrder { get; set; }

        //[NotMapped]
        public string ProductGroup { get; set; }

        /// <summary>
        /// A regex filter to apply to the options. Id's which don't match will not be selectable by users.
        /// </summary>
        //[NotMapped]
        public string OptionSelectionFilter { get; set; }

        [XmlElement("Price")]
        public PriceDetails Price { get; set; }

        public class InfoDetails
        {
            [XmlElement("Name")]
            public string Name { get; set; }

            [XmlElement("Description")]
            public string Description { get; set; }

            [XmlElement("SumAssured")]
            public SumAssuredDetails SumAssured { get; set; }
        }

        public class SumAssuredDetails
        {
            [XmlElement("Minimum")]
            public decimal Minimum { get; set; }

            [XmlElement("Maximum")]
            public decimal Maximum { get; set; }
        }

        public class PlansOrOptionsDetails
        {
            [XmlElement("Option")]
            public List<OptionDetails> Options { get; set; }

            public bool AllowCustomSumAssured()
            {
                return Options.Any(o => o.Name == SumAssuredCustomAmountToken);
            }
        }

        public class OptionDetails
        {
            [XmlAttribute("ID")]
            public string Id { get; set; }

            [XmlElement("Name")]
            public string Name { get; set; }

            [XmlElement("Description")]
            public string Description { get; set; }

            [XmlElement("Value")]
            public string Value { get; set; }

            [XmlAttribute("Value")]
            public string LinkLogicValue { get; set; }

            [XmlAttribute("GroupValue")]
            public string LinkLogicGroupValue { get; set; }

            [XmlElement("DescriptionLine1")]
            public string DescriptionLine1 { get; set; }

            [XmlElement("DescriptionLine2")]
            public string ValDescriptionLine2 { get; set; }

            [XmlElement("GroupName")]
            public string GroupName { get; set; }

            [XmlElement("Price")]
            public PlanBasedPrice Price { get; set; } //Plan based only.
        }

        public class PriceDetails
        {
            [XmlAttribute("Method")]
            public PriceMethod Method { get; set; }
            [XmlElement("Rates")]
            public List<PriceRateDetails> Rates { get; set; }
        }

        public class PriceRateDetails
        {
            [XmlAttribute("Method")]
            public RatesMethod Method { get; set; }
            [XmlElement("Member")]
            public List<PriceRateMemberDetails> Members { get; set; }
        }

        public class PriceRateMemberDetails
        {
            [XmlAttribute("Type")]
            public MemberType Type { get; set; }
            [XmlElement("Tiers")]
            public PriceRateMemberTiersDetails TiersContainer { get; set; }
        }

        public class PriceRateMemberTiersDetails
        {
            [XmlElement("Tier")]
            public List<PriceRateMemberTierDetails> Tiers { get; set; }
        }

        public class PriceRateMemberTierDetails
        {
            [XmlAttribute("Level")]
            public string Level { get; set; }
            [XmlElement("Rate")]
            public PriceRate Rate { get; set; }
            [XmlElement("PriceLabel")]
            public string PriceLabel { get; set; }
        }

        public class PriceRate
        {
            [XmlText]
            public string Rate { get; set; }
            [XmlAttribute("Unit")]
            public string Unit { get; set; }
        }

        public class PlanBasedPrice
        {
            [XmlAttribute("Method")]
            public PriceMethod Method { get; set; }

            [XmlElement("Rates")]
            public PlanBasedPriceRates Rates { get; set; }
        }

        public class PlanBasedPriceRates
        {
            [XmlAttribute("Method")]
            public RatesMethod Method { get; set; }

            [XmlElement("Member")]
            public List<PlanBasedPriceRatesMember> Members { get; set; }
        }

        public class PlanBasedPriceRatesMember
        {
            [XmlAttribute("Type")]
            public MemberType Type { get; set; }

            [XmlElement("Pricing")]
            public PlanBasedPriceRatesMemberPricing Pricing { get; set; }
        }

        public class PlanBasedPriceRatesMemberPricing
        {
            [XmlElement("Rate")]
            public string RateFormula { get; set; }
        }
    }

    public static class Constants
    {
        public static string BenefitConfig
        {
            get
            {
                return @"<Benefit ID=""GDT"" Type=""PlanBased"" Logo=""DentalIcon.png"">
  <Selection Selectable=""True"" />
  <Info>
    <Name>Group Dental</Name>
    <Description>When it comes to good dental health, prevention is better than cure. Many dental problems progress slowly, but a dentist is trained to detect these early and provide timely treatment. This is why it is important to go for your regular dental check-ups.</Description>
    <ProductSummary>
      <AlertMessage />
      <ProdSummary />
      <ProdSummary />
    </ProductSummary>
    <SumAssured>
      <Minimum>0</Minimum>
      <Maximum>0</Maximum>
    </SumAssured>
    <BriefDescription>Covers you for allowed treatments at a dental clinic. Choose your coverage.</BriefDescription>
    <InsurerCode>NEX</InsurerCode>
    <PolicyNumber />
    <DataFeed>True</DataFeed>
    <DocumentCheck>False</DocumentCheck>
    <HideProduct EnrolmentFlag=""False"" BenefitSummaryFlag=""False"">
      <HidingRule />
    </HideProduct>
  </Info>
  <Eligibility>
    <Eligible ID=""{CATID}EE"" MemberType=""Employee"">
      <Name>{CategoryName}EE</Name>
      <Rules>(
	EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 66
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 67 AND 73 			AND 
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] IS NOT NULL 		AND
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] NOT IN ('0x', '0n', '0000')
	) 
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 73 AND
		EmployeeAge.[FlexPlanID] = 'Initial'
	)
)
AND Employee.[Category] = '{CategoryName}'
AND EmployeeFamily.[MedicalFamilyBasis] = 'EE'</Rules>
      <RulesBA>(
	EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 66
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 67 AND 73 			AND 
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] IS NOT NULL 		AND
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] NOT IN ('0x', '0n', '0000')
	) 
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 73 AND
		EmployeeAge.[FlexPlanID] = 'Initial'
	)
)
AND Employee.[Category] = '{CategoryName}'
AND EmployeeFamily.[MedicalFamilyBasis] = 'EE'</RulesBA>
      <RulesJSON />
      <DependantRules />
      <DependantRulesBA />
      <DependantRulesJSON />
      <PlansOrOptions>
        <Option ID=""Plan04EE"" />
      </PlansOrOptions>
      <DefaultPlansOrOptions>
        <ForExistingEmployee Default=""Plan04EE"" />
        <ForNewHire Default=""Plan04EE"" />
      </DefaultPlansOrOptions>
    </Eligible>
    <Eligible ID=""{CATID}ES"" MemberType=""AllMembers"">
      <Name>{CategoryName}ES</Name>
      <Rules>(
	EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 66
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 67 AND 73 			AND 
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] IS NOT NULL 		AND
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] NOT IN ('0x', '0n', '0000')
	) 
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 73 AND
		EmployeeAge.[FlexPlanID] = 'Initial'
	)
)
AND Employee.[Category] = '{CategoryName}'
AND EmployeeFamily.[MedicalFamilyBasis] = 'ES'</Rules>
      <RulesBA>(
	EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 66
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 67 AND 73 			AND 
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] IS NOT NULL 		AND
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] NOT IN ('0x', '0n', '0000')
	) 
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 73 AND
		EmployeeAge.[FlexPlanID] = 'Initial'
	)
)
AND Employee.[Category] = '{CategoryName}'
AND EmployeeFamily.[MedicalFamilyBasis] = 'ES'</RulesBA>
      <RulesJSON />
      <DependantRules>(
	(
		Dependant.[Relationship] IN ('Child','Children','Son','Daughter') AND 
		DependantAge.[AgeNextBirthday] BETWEEN 1 AND 25 AND Dependant.[DateInFlex] IS NULL
	) 
	OR
	(
		Dependant.[Relationship] IN ('Child','Children','Son','Daughter') AND 
		DependantAge.[FlexAgeNextBirthday] BETWEEN 1 AND 25 AND Dependant.[DateInFlex] IS NOT NULL
	) 
	OR
	(
		Dependant.[Relationship] IN ('Spouse','Husband','Wife') AND 
		DependantAge.[AgeNextBirthday] BETWEEN 1 AND 66 AND Dependant.[DateInFlex] IS NULL
	)
	OR
	(
		Dependant.[Relationship] IN ('Spouse','Husband','Wife') AND 
		DependantAge.[FlexAgeNextBirthday] BETWEEN 1 AND 66 AND Dependant.[DateInFlex] IS NOT NULL
	)
)
AND
(
	Dependant.[TerminationDate] IS NULL 
	OR 
	Dependant.[TerminationDate] &gt;= GETDATE()
) 
AND Dependant.[IsInMedical] = 1 </DependantRules>
      <DependantRulesBA>[DependantInMedicalRules] 
AND Dependant.[IsInMedical] = 1 </DependantRulesBA>
      <DependantRulesJSON />
      <PlansOrOptions>
        <Option ID=""Plan04ES"" />
      </PlansOrOptions>
      <DefaultPlansOrOptions>
        <ForExistingEmployee Default=""Plan04ES"" />
        <ForNewHire Default=""Plan04ES"" />
      </DefaultPlansOrOptions>
    </Eligible>
    <Eligible ID=""{CATID}EC"" MemberType=""AllMembers"">
      <Name>{CategoryName}EC</Name>
      <Rules>(
	EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 66
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 67 AND 73 			AND 
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] IS NOT NULL 		AND
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] NOT IN ('0x', '0n', '0000')
	) 
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 73 AND
		EmployeeAge.[FlexPlanID] = 'Initial'
	)
)
AND Employee.[Category] = '{CategoryName}'
AND EmployeeFamily.[MedicalFamilyBasis] = 'EC'</Rules>
      <RulesBA>(
	EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 66
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 67 AND 73 			AND 
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] IS NOT NULL 		AND
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] NOT IN ('0x', '0n', '0000')
	) 
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 73 AND
		EmployeeAge.[FlexPlanID] = 'Initial'
	)
)
AND Employee.[Category] = '{CategoryName}'
AND EmployeeFamily.[MedicalFamilyBasis] = 'EC'</RulesBA>
      <RulesJSON />
      <DependantRules>(
	(
		Dependant.[Relationship] IN ('Child','Children','Son','Daughter') AND 
		DependantAge.[AgeNextBirthday] BETWEEN 1 AND 25 AND Dependant.[DateInFlex] IS NULL
	) 
	OR
	(
		Dependant.[Relationship] IN ('Child','Children','Son','Daughter') AND 
		DependantAge.[FlexAgeNextBirthday] BETWEEN 1 AND 25 AND Dependant.[DateInFlex] IS NOT NULL
	) 
	OR
	(
		Dependant.[Relationship] IN ('Spouse','Husband','Wife') AND 
		DependantAge.[AgeNextBirthday] BETWEEN 1 AND 66 AND Dependant.[DateInFlex] IS NULL
	)
	OR
	(
		Dependant.[Relationship] IN ('Spouse','Husband','Wife') AND 
		DependantAge.[FlexAgeNextBirthday] BETWEEN 1 AND 66 AND Dependant.[DateInFlex] IS NOT NULL
	)
)
AND
(
	Dependant.[TerminationDate] IS NULL 
	OR 
	Dependant.[TerminationDate] &gt;= GETDATE()
) 
AND Dependant.[IsInMedical] = 1 </DependantRules>
      <DependantRulesBA>[DependantInMedicalRules] 
AND Dependant.[IsInMedical] = 1 </DependantRulesBA>
      <DependantRulesJSON />
      <PlansOrOptions>
        <Option ID=""Plan04EC"" />
      </PlansOrOptions>
      <DefaultPlansOrOptions>
        <ForExistingEmployee Default=""Plan04EC"" />
        <ForNewHire Default=""Plan04EC"" />
      </DefaultPlansOrOptions>
    </Eligible>
    <Eligible ID=""{CATID}EF"" MemberType=""AllMembers"">
      <Name>{CategoryName}EF</Name>
      <Rules>(
	EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 66
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 67 AND 73 			AND 
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] IS NOT NULL 		AND
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] NOT IN ('0x', '0n', '0000')
	) 
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 73 AND
		EmployeeAge.[FlexPlanID] = 'Initial'
	)
)
AND Employee.[Category] = '{CategoryName}'
AND EmployeeFamily.[MedicalFamilyBasis] = 'EF'</Rules>
      <RulesBA>(
	EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 66
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 67 AND 73 			AND 
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] IS NOT NULL 		AND
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] NOT IN ('0x', '0n', '0000')
	) 
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 73 AND
		EmployeeAge.[FlexPlanID] = 'Initial'
	)
)
AND Employee.[Category] = '{CategoryName}'
AND EmployeeFamily.[MedicalFamilyBasis] = 'EF'</RulesBA>
      <RulesJSON />
      <DependantRules>(
	(
		Dependant.[Relationship] IN ('Child','Children','Son','Daughter') AND 
		DependantAge.[AgeNextBirthday] BETWEEN 1 AND 25 AND Dependant.[DateInFlex] IS NULL
	) 
	OR
	(
		Dependant.[Relationship] IN ('Child','Children','Son','Daughter') AND 
		DependantAge.[FlexAgeNextBirthday] BETWEEN 1 AND 25 AND Dependant.[DateInFlex] IS NOT NULL
	) 
	OR
	(
		Dependant.[Relationship] IN ('Spouse','Husband','Wife') AND 
		DependantAge.[AgeNextBirthday] BETWEEN 1 AND 66 AND Dependant.[DateInFlex] IS NULL
	)
	OR
	(
		Dependant.[Relationship] IN ('Spouse','Husband','Wife') AND 
		DependantAge.[FlexAgeNextBirthday] BETWEEN 1 AND 66 AND Dependant.[DateInFlex] IS NOT NULL
	)
)
AND
(
	Dependant.[TerminationDate] IS NULL 
	OR 
	Dependant.[TerminationDate] &gt;= GETDATE()
) 
AND Dependant.[IsInMedical] = 1 </DependantRules>
      <DependantRulesBA>[DependantInMedicalRules] 
AND Dependant.[IsInMedical] = 1 </DependantRulesBA>
      <DependantRulesJSON />
      <PlansOrOptions>
        <Option ID=""Plan04EF"" />
      </PlansOrOptions>
      <DefaultPlansOrOptions>
        <ForExistingEmployee Default=""Plan04EF"" />
        <ForNewHire Default=""Plan04EF"" />
      </DefaultPlansOrOptions>
    </Eligible>
    <Eligible ID=""{CATID}"" MemberType=""Employee"">
      <Name>{CategoryName}</Name>
      <Rules>(
	EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 66
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 67 AND 73 			AND 
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] IS NOT NULL 		AND
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] NOT IN ('0x', '0n', '0000')
	) 
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 73 AND
		EmployeeAge.[FlexPlanID] = 'Initial'
	)
)
AND Employee.[Category] = '{CategoryName}'</Rules>
      <RulesBA>(
	EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 66
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 67 AND 73 			AND 
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] IS NOT NULL 		AND
		EmployeePreviousBenefit.[OptionOrPlanIDFinal] NOT IN ('0x', '0n', '0000')
	) 
	OR
	(
		EmployeeAge.[FlexAgeNextBirthday] BETWEEN 1 AND 73 AND
		EmployeeAge.[FlexPlanID] = 'Initial'
	)
)
AND Employee.[Category] = '{CategoryName}'</RulesBA>
      <RulesJSON />
      <DependantRules />
      <DependantRulesBA />
      <DependantRulesJSON />
      <PlansOrOptions>
        <Option ID=""Plan04EE"" />
      </PlansOrOptions>
      <DefaultPlansOrOptions>
        <ForExistingEmployee Default=""Plan04EE"" />
        <ForNewHire Default=""Plan04EE"" />
      </DefaultPlansOrOptions>
    </Eligible>
  </Eligibility>
  <PlansOrOptions EnrolMode=""PerMemberLimitToSamePlan"">
    <Option ID=""0000"" Value=""0"" GroupID="""" GroupValue=""0"" Method=""NotSelectable"">
      <Name>No Cover</Name>
      <GroupName />
      <Description>No Cover</Description>
      <Cover>
        <MemberType>Employee</MemberType>
      </Cover>
      <Price Method=""Group"" Prorate=""true"">
        <Rates Method=""AllMemberSamePrice"">
          <Member Type=""AllMembers"">
            <Pricing>
              <Rate>0</Rate>
              <RateBA>0</RateBA>
              <PriceLabel>$0</PriceLabel>
            </Pricing>
          </Member>
        </Rates>
      </Price>
      <SelectionUI Method="""" />
    </Option>
    <Option ID=""Plan04EE"" Value=""1"" GroupID=""D"" GroupValue=""4"" Method=""NotSelectable"">
      <Name>Panel &amp; Non Panel (Employee Only)</Name>
      <GroupName />
      <Description>Panel Dental</Description>
      <Cover>
        <MemberType>Employee</MemberType>
      </Cover>
      <Price Method=""PerMember"" Prorate=""true"">
        <Rates Method=""AllMemberSamePrice"">
          <Member Type=""AllMembers"">
            <Pricing>
              <Rate>240.00 * 1.07</Rate>
              <RateBA>240.00 * 1.07</RateBA>
              <PriceLabel>$[ComputedPriceTag]</PriceLabel>
            </Pricing>
          </Member>
        </Rates>
      </Price>
      <SelectionUI Method=""NotSelectable"" />
    </Option>
    <Option ID=""Plan04ES"" Value=""2"" GroupID=""D"" GroupValue=""4"" Method=""NotSelectable"">
      <Name>Panel &amp; Non Panel (Employee and Spouse Only)</Name>
      <GroupName />
      <Description>Panel Dental</Description>
      <Cover>
        <MemberType>Employee</MemberType>
        <MemberType Selection=""OneInAllIn"" LimitDependantType=""LimitDependantTypeSpouse"">Dependant</MemberType>
      </Cover>
      <Price Method=""PerMember"" Prorate=""true"">
        <Rates Method=""AllMemberSamePrice"">
          <Member Type=""AllMembers"">
            <Pricing>
              <Rate>240.00 * 1.07</Rate>
              <RateBA>240.00 * 1.07</RateBA>
              <PriceLabel>$[ComputedPriceTag]</PriceLabel>
            </Pricing>
          </Member>
        </Rates>
      </Price>
      <SelectionUI Method=""NotSelectable"" />
    </Option>
    <Option ID=""Plan04EC"" Value=""2"" GroupID=""D"" GroupValue=""4"" Method=""NotSelectable"">
      <Name>Panel &amp; Non Panel (Employee and Children Only)</Name>
      <GroupName />
      <Description>Panel Dental</Description>
      <Cover>
        <MemberType>Employee</MemberType>
        <MemberType Selection=""OneInAllIn"" LimitDependantType=""LimitDependantTypeChildren"">Dependant</MemberType>
      </Cover>
      <Price Method=""PerMember"" Prorate=""true"">
        <Rates Method=""AllMemberSamePrice"">
          <Member Type=""AllMembers"">
            <Pricing>
              <Rate>240.00 * 1.07</Rate>
              <RateBA>240.00 * 1.07</RateBA>
              <PriceLabel>$[ComputedPriceTag]</PriceLabel>
            </Pricing>
          </Member>
        </Rates>
      </Price>
      <SelectionUI Method=""NotSelectable"" />
    </Option>
    <Option ID=""Plan04EF"" Value=""3"" GroupID=""D"" GroupValue=""4"" Method=""NotSelectable"">
      <Name>Panel &amp; Non Panel (Employee and Family)</Name>
      <GroupName />
      <Description>Panel Dental</Description>
      <Cover>
        <MemberType>Employee</MemberType>
        <MemberType Selection=""OneInAllIn"" LimitDependantType=""LimitDependantTypeSpouseAndChildren"">Dependant</MemberType>
      </Cover>
      <Price Method=""PerMember"" Prorate=""true"">
        <Rates Method=""AllMemberSamePrice"">
          <Member Type=""AllMembers"">
            <Pricing>
              <Rate>240.00 * 1.07</Rate>
              <RateBA>240.00 * 1.07</RateBA>
              <PriceLabel>$[ComputedPriceTag]</PriceLabel>
            </Pricing>
          </Member>
        </Rates>
      </Price>
      <SelectionUI Method=""NotSelectable"" />
    </Option>
    <Option ID=""Plan00EE"" Value=""0"" GroupID="""" GroupValue=""0"" Method=""NotSelectable"">
      <Name>Under Flex Wallet</Name>
      <GroupName />
      <Description>Under Flex Wallet</Description>
      <Cover>
        <MemberType>Employee</MemberType>
      </Cover>
      <Price Method=""Group"" Prorate=""true"">
        <Rates Method=""AllMemberSamePrice"">
          <Member Type=""AllMembers"">
            <Pricing>
              <Rate>0</Rate>
              <RateBA>0</RateBA>
              <PriceLabel>$0</PriceLabel>
            </Pricing>
          </Member>
        </Rates>
      </Price>
      <SelectionUI Method="""" />
    </Option>
  </PlansOrOptions>
  <UISettings>
    <Setting ID=""DisplayGroupName"" Value=""false"" />
    <Setting ID=""DisplayPlanDescription"" Value=""true"" />
    <Setting ID=""ShowGrouping"" Value=""false"" />
  </UISettings>
</Benefit>";
            }
        }
    }
}
