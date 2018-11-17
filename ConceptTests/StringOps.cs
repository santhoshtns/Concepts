using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConceptTests
{
    public class StringOps
    {
        private static string _benefitsStartString = "<!--LOOP_BENEFIT_START-->";
        private static string _benefitsEndString = "<!--LOOP_BENEFIT_END-->";
        
        public static void PerformFetchAndReplace()
        {
            var decodedHtml = HttpUtility.HtmlDecode(_clientSignupInvoiceEmailTemplate);
            var indexStart = decodedHtml.IndexOf(_benefitsStartString);
            var indexEnd = decodedHtml.IndexOf(_benefitsEndString);
            var benefitTemplate = decodedHtml.Substring(indexStart + _benefitsStartString.Length,
                indexEnd - indexStart - _benefitsStartString.Length);
            var benefitsHtml = new StringBuilder();
            {
                benefitsHtml.Append(benefitTemplate
                    .Replace("{{BENEFIT}}", "benefit.Name")
                    .Replace("{{BENEFIT_OPTION}}", "benefit.Option"));
            }
            var result = decodedHtml.Replace(benefitTemplate, benefitsHtml.ToString());
            var cnt = result.Count();
        }

        private static string _clientSignupInvoiceEmailTemplate = @"&lt;!doctype html&gt;
&lt;html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office""&gt;

&lt;head&gt;
  &lt;title&gt; &lt;/title&gt;
  &lt;!--[if !mso]&gt;&lt;!-- --&gt;
  &lt;meta http-equiv=""X-UA-Compatible"" content=""IE=edge""&gt;
  &lt;!--&lt;![endif]--&gt;
  &lt;meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8""&gt;
  &lt;meta name=""viewport"" content=""width=device-width, initial-scale=1""&gt;
  &lt;style type=""text/css""&gt;
    #outlook a {
      padding: 0;
    }

    .ReadMsgBody {
      width: 100%;
    }

    .ExternalClass {
      width: 100%;
    }

    .ExternalClass * {
      line-height: 100%;
    }

    body {
      margin: 0;
      padding: 0;
      -webkit-text-size-adjust: 100%;
      -ms-text-size-adjust: 100%;
    }

    table,
    td {
      border-collapse: collapse;
      mso-table-lspace: 0pt;
      mso-table-rspace: 0pt;
    }

    img {
      border: 0;
      height: auto;
      line-height: 100%;
      outline: none;
      text-decoration: none;
      -ms-interpolation-mode: bicubic;
    }

    p {
      display: block;
      margin: 13px 0;
    }
  &lt;/style&gt;
  &lt;!--[if !mso]&gt;&lt;!--&gt;
  &lt;style type=""text/css""&gt;
    @media only screen and (max-width:480px) {
      @-ms-viewport {
        width: 320px;
      }
      @viewport {
        width: 320px;
      }
    }
  &lt;/style&gt;
  &lt;!--&lt;![endif]--&gt;
  &lt;!--[if mso]&gt;
        &lt;xml&gt;
        &lt;o:OfficeDocumentSettings&gt;
          &lt;o:AllowPNG/&gt;
          &lt;o:PixelsPerInch&gt;96&lt;/o:PixelsPerInch&gt;
        &lt;/o:OfficeDocumentSettings&gt;
        &lt;/xml&gt;
        &lt;![endif]--&gt;
  &lt;!--[if lte mso 11]&gt;
        &lt;style type=""text/css""&gt;
          .outlook-group-fix { width:100% !important; }
        &lt;/style&gt;
        &lt;![endif]--&gt;
  &lt;style type=""text/css""&gt;
    @media only screen and (min-width:480px) {
      .mj-column-per-100 {
        width: 100% !important;
        max-width: 100%;
      }
      .mj-column-per-50 {
        width: 50% !important;
        max-width: 50%;
      }
    }
  &lt;/style&gt;
  &lt;style type=""text/css""&gt;
    @media only screen and (max-width:480px) {
      table.full-width-mobile {
        width: 100% !important;
      }
      td.full-width-mobile {
        width: auto !important;
      }
    }
  &lt;/style&gt;
&lt;/head&gt;

&lt;body style=""background-color:#F2F2F2;""&gt;
  &lt;div style=""background-color:#F2F2F2;""&gt;
    &lt;!--[if mso | IE]&gt;
      &lt;table
         align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""" style=""width:720px;"" width=""720""
      &gt;
        &lt;tr&gt;
          &lt;td style=""line-height:0px;font-size:0px;mso-line-height-rule:exactly;""&gt;
      &lt;![endif]--&gt;
    &lt;div style=""Margin:0px auto;max-width:720px;""&gt;
      &lt;table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""width:100%;""&gt;
        &lt;tbody&gt;
          &lt;tr&gt;
            &lt;td style=""direction:ltr;font-size:0px;padding:20px 0;text-align:center;vertical-align:top;""&gt;
              &lt;!--[if mso | IE]&gt;
                  &lt;table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0""&gt;
                
        &lt;tr&gt;
      
            &lt;td
               class="""" style=""vertical-align:top;width:720px;""
            &gt;
          &lt;![endif]--&gt;
              &lt;div class=""mj-column-per-100 outlook-group-fix"" style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;""&gt;
                &lt;table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""vertical-align:top;"" width=""100%""&gt;
                  &lt;tr&gt;
                    &lt;td align=""right"" style=""font-size:0px;padding:10px 25px;word-break:break-word;""&gt;
                      &lt;table align=""right"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""border-collapse:collapse;border-spacing:0px;""&gt;
                        &lt;tbody&gt;
                          &lt;tr&gt;
                            &lt;td style=""width:100px;""&gt; &lt;img height=""auto"" src=""https://mjml.io/assets/img/logo-small.png"" style=""border:0;display:block;outline:none;text-decoration:none;height:auto;width:100%;"" width=""100"" /&gt; &lt;/td&gt;
                          &lt;/tr&gt;
                        &lt;/tbody&gt;
                      &lt;/table&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                &lt;/table&gt;
              &lt;/div&gt;
              &lt;!--[if mso | IE]&gt;
            &lt;/td&gt;
          
        &lt;/tr&gt;
      
                  &lt;/table&gt;
                &lt;![endif]--&gt;
            &lt;/td&gt;
          &lt;/tr&gt;
        &lt;/tbody&gt;
      &lt;/table&gt;
    &lt;/div&gt;
    &lt;!--[if mso | IE]&gt;
          &lt;/td&gt;
        &lt;/tr&gt;
      &lt;/table&gt;
      
      &lt;table
         align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""" style=""width:720px;"" width=""720""
      &gt;
        &lt;tr&gt;
          &lt;td style=""line-height:0px;font-size:0px;mso-line-height-rule:exactly;""&gt;
      
        &lt;v:rect  style=""width:720px;"" xmlns:v=""urn:schemas-microsoft-com:vml"" fill=""true"" stroke=""false""&gt;
        &lt;v:fill  origin=""0.5, 0"" position=""0.5, 0"" src=""https://cxa-email.surge.sh/email-bg.png"" type=""tile"" /&gt;
        &lt;v:textbox style=""mso-fit-shape-to-text:true"" inset=""0,0,0,0""&gt;
      &lt;![endif]--&gt;
    &lt;div style=""background:url(https://cxa-email.surge.sh/email-bg.png) top center / cover no-repeat;Margin:0px auto;max-width:720px;""&gt;
      &lt;div style=""line-height:0;font-size:0;""&gt;
        &lt;table align=""center"" background=""https://cxa-email.surge.sh/email-bg.png"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""background:url(https://cxa-email.surge.sh/email-bg.png) top center / cover no-repeat;width:100%;""&gt;
          &lt;tbody&gt;
            &lt;tr&gt;
              &lt;td style=""direction:ltr;font-size:0px;padding:20px 0;padding-bottom:36px;padding-top:36px;text-align:center;vertical-align:top;""&gt;
                &lt;!--[if mso | IE]&gt;
                  &lt;table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0""&gt;
                
        &lt;tr&gt;
      
            &lt;td
               class="""" style=""vertical-align:top;width:720px;""
            &gt;
          &lt;![endif]--&gt;
                &lt;div class=""mj-column-per-100 outlook-group-fix"" style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;""&gt;
                  &lt;table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""vertical-align:top;"" width=""100%""&gt;
                    &lt;tr&gt;
                      &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;padding-bottom:10px;word-break:break-word;""&gt;
                        &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:24px;font-weight:400;line-height:28px;text-align:left;color:#fff;""&gt; Hello {{CLIENT}}, &lt;/div&gt;
                      &lt;/td&gt;
                    &lt;/tr&gt;
                    &lt;tr&gt;
                      &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;padding-bottom:10px;word-break:break-word;""&gt;
                        &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:40px;font-weight:bold;line-height:48px;text-align:left;color:#fff;""&gt; Thank you &lt;/div&gt;
                      &lt;/td&gt;
                    &lt;/tr&gt;
                    &lt;tr&gt;
                      &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;word-break:break-word;""&gt;
                        &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:24px;font-weight:bold;line-height:28px;text-align:left;color:#fff;""&gt; for your interest in the Employee Benefits package &lt;/div&gt;
                      &lt;/td&gt;
                    &lt;/tr&gt;
                  &lt;/table&gt;
                &lt;/div&gt;
                &lt;!--[if mso | IE]&gt;
            &lt;/td&gt;
          
        &lt;/tr&gt;
      
                  &lt;/table&gt;
                &lt;![endif]--&gt;
              &lt;/td&gt;
            &lt;/tr&gt;
          &lt;/tbody&gt;
        &lt;/table&gt;
      &lt;/div&gt;
    &lt;/div&gt;
    &lt;!--[if mso | IE]&gt;
        &lt;/v:textbox&gt;
      &lt;/v:rect&gt;
    
          &lt;/td&gt;
        &lt;/tr&gt;
      &lt;/table&gt;
      
      &lt;table
         align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""" style=""width:720px;"" width=""720""
      &gt;
        &lt;tr&gt;
          &lt;td style=""line-height:0px;font-size:0px;mso-line-height-rule:exactly;""&gt;
      &lt;![endif]--&gt;
    &lt;div style=""background:white;background-color:white;Margin:0px auto;max-width:720px;""&gt;
      &lt;table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""background:white;background-color:white;width:100%;""&gt;
        &lt;tbody&gt;
          &lt;tr&gt;
            &lt;td style=""direction:ltr;font-size:0px;padding:20px 0;padding-bottom:36px;padding-top:36px;text-align:center;vertical-align:top;""&gt;
              &lt;!--[if mso | IE]&gt;
                  &lt;table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0""&gt;
                
        &lt;tr&gt;
      
            &lt;td
               class="""" style=""vertical-align:top;width:720px;""
            &gt;
          &lt;![endif]--&gt;
              &lt;div class=""mj-column-per-100 outlook-group-fix"" style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;""&gt;
                &lt;table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""vertical-align:top;"" width=""100%""&gt;
                  &lt;tr&gt;
                    &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;padding-bottom:12px;word-break:break-word;""&gt;
                      &lt;div style=""font-family:Helvetica Neue;font-size:24px;font-weight:bold;line-height:24px;text-align:left;color:red;""&gt; What's next? &lt;/div&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                  &lt;tr&gt;
                    &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;word-break:break-word;""&gt;
                      &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:16px;font-weight:400;line-height:24px;text-align:left;color:#444;""&gt; Please proceed to make payment via the portal. &lt;/div&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                  &lt;tr&gt;
                    &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;word-break:break-word;""&gt;
                      &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:16px;font-weight:400;line-height:24px;text-align:left;color:#444;""&gt; Upon successful payment, you need to submit the following documents via the portal. &lt;/div&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                  &lt;tr&gt;
                    &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;padding-top:0;word-break:break-word;""&gt;
                      &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:16px;font-weight:400;line-height:24px;text-align:left;color:#444;""&gt;
                        &lt;ul style=""padding-left: 24px""&gt;
                          &lt;li&gt;Employee Census Data&lt;/li&gt;
                          &lt;li style=""padding-top: 10px""&gt;ACRA Business Profile&lt;/li&gt;
                          &lt;li style=""padding-top: 10px""&gt;MAS314 Form&lt;/li&gt;
                          &lt;li style=""padding-top: 10px""&gt;Proof of Bank Transfer / Cheque Deposit&lt;/li&gt;
                        &lt;/ul&gt;
                      &lt;/div&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                  &lt;tr&gt;
                    &lt;td style=""font-size:0px;padding:10px 25px;word-break:break-word;""&gt;
                      &lt;p style=""border-top:solid 1px #ea2a27;font-size:1;margin:0px auto;width:100%;""&gt; &lt;/p&gt;
                      &lt;!--[if mso | IE]&gt;
        &lt;table
           align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-top:solid 1px #ea2a27;font-size:1;margin:0px auto;width:670px;"" role=""presentation"" width=""670px""
        &gt;
          &lt;tr&gt;
            &lt;td style=""height:0;line-height:0;""&gt;
              &amp;nbsp;
            &lt;/td&gt;
          &lt;/tr&gt;
        &lt;/table&gt;
      &lt;![endif]--&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                  &lt;tr&gt;
                    &lt;td align=""left"" style=""font-size:0px;padding:10px 25px;padding-bottom:20px;word-break:break-word;""&gt;
                      &lt;table cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"" style=""cellspacing:0;color:#444;font-family:'Helvetica Neue', Arial, sans-serif;font-size:14px;line-height:22px;table-layout:auto;width:100%;""&gt;
                        &lt;tr style=""font-style: italic; vertical-align: top""&gt;
                          &lt;td width=""24px""&gt;-&lt;/td&gt;
                          &lt;td&gt;Insurance cover will not be effective until the above documents are submitted&lt;/td&gt;
                        &lt;/tr&gt;
                        &lt;tr style=""font-style: italic; vertical-align: top""&gt;
                          &lt;td width=""24px""&gt;-&lt;/td&gt;
                          &lt;td&gt;Submit all documents by tomorrow, otherwise the insurance coverage start date selected may not be valid and you need to select a new date after you submit the documents.&lt;/td&gt;
                        &lt;/tr&gt;
                      &lt;/table&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                  &lt;tr&gt;
                    &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;word-break:break-word;""&gt;
                      &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:16px;font-weight:400;line-height:24px;text-align:left;color:#444;""&gt; You can click on the below button to complete your Employee Benefits purchase. &lt;/div&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                  &lt;tr&gt;
                    &lt;td align=""left"" vertical-align=""middle"" style=""font-size:0px;padding:10px 25px;word-break:break-word;""&gt;
                      &lt;table align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""border-collapse:separate;line-height:100%;""&gt;
                        &lt;tr&gt;
                          &lt;td align=""center"" bgcolor=""#ea2a27"" role=""presentation"" style=""border:none;border-radius:3px;cursor:auto;padding:15px 30px;"" valign=""middle""&gt; &lt;a href=""[CONTINUE_HREF]"" style=""background:#ea2a27;color:white;font-family:'Helvetica Neue', Arial, sans-serif;font-size:16px;font-weight:normal;line-height:120%;Margin:0;text-decoration:none;text-transform:none;"" target=""_blank""&gt;
              Continue
            &lt;/a&gt; &lt;/td&gt;
                        &lt;/tr&gt;
                      &lt;/table&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                &lt;/table&gt;
              &lt;/div&gt;
              &lt;!--[if mso | IE]&gt;
            &lt;/td&gt;
          
        &lt;/tr&gt;
      
                  &lt;/table&gt;
                &lt;![endif]--&gt;
            &lt;/td&gt;
          &lt;/tr&gt;
        &lt;/tbody&gt;
      &lt;/table&gt;
    &lt;/div&gt;
    &lt;!--[if mso | IE]&gt;
          &lt;/td&gt;
        &lt;/tr&gt;
      &lt;/table&gt;
      
      &lt;table
         align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""" style=""width:720px;"" width=""720""
      &gt;
        &lt;tr&gt;
          &lt;td style=""line-height:0px;font-size:0px;mso-line-height-rule:exactly;""&gt;
      &lt;![endif]--&gt;
    &lt;div style=""Margin:0px auto;max-width:720px;""&gt;
      &lt;table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""width:100%;""&gt;
        &lt;tbody&gt;
          &lt;tr&gt;
            &lt;td style=""direction:ltr;font-size:0px;padding:20px 0;padding-bottom:0;padding-top:36px;text-align:center;vertical-align:top;""&gt;
              &lt;!--[if mso | IE]&gt;
                  &lt;table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0""&gt;
                
        &lt;tr&gt;
      
            &lt;td
               class="""" style=""vertical-align:top;width:720px;""
            &gt;
          &lt;![endif]--&gt;
              &lt;div class=""mj-column-per-100 outlook-group-fix"" style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;""&gt;
                &lt;table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""vertical-align:top;"" width=""100%""&gt;
                  &lt;tr&gt;
                    &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;word-break:break-word;""&gt;
                      &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:18px;font-weight:bold;line-height:24px;text-align:left;color:#444;""&gt; Package Summary &lt;/div&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                  &lt;tr&gt;
                    &lt;td style=""font-size:0px;padding:10px 25px;word-break:break-word;""&gt;
                      &lt;p style=""border-top:solid 1px #ea2a27;font-size:1;margin:0px auto;width:100%;""&gt; &lt;/p&gt;
                      &lt;!--[if mso | IE]&gt;
        &lt;table
           align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-top:solid 1px #ea2a27;font-size:1;margin:0px auto;width:670px;"" role=""presentation"" width=""670px""
        &gt;
          &lt;tr&gt;
            &lt;td style=""height:0;line-height:0;""&gt;
              &amp;nbsp;
            &lt;/td&gt;
          &lt;/tr&gt;
        &lt;/table&gt;
      &lt;![endif]--&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                &lt;/table&gt;
              &lt;/div&gt;
              &lt;!--[if mso | IE]&gt;
            &lt;/td&gt;
          
        &lt;/tr&gt;
      
                  &lt;/table&gt;
                &lt;![endif]--&gt;
            &lt;/td&gt;
          &lt;/tr&gt;
        &lt;/tbody&gt;
      &lt;/table&gt;
    &lt;/div&gt;
    &lt;!--[if mso | IE]&gt;
          &lt;/td&gt;
        &lt;/tr&gt;
      &lt;/table&gt;
      
      &lt;table
         align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""" style=""width:720px;"" width=""720""
      &gt;
        &lt;tr&gt;
          &lt;td style=""line-height:0px;font-size:0px;mso-line-height-rule:exactly;""&gt;
      &lt;![endif]--&gt;
    &lt;div style=""Margin:0px auto;max-width:720px;""&gt;
      &lt;table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""width:100%;""&gt;
        &lt;tbody&gt;
          &lt;tr&gt;
            &lt;td style=""direction:ltr;font-size:0px;padding:20px 0;padding-bottom:0;padding-top:0;text-align:center;vertical-align:top;""&gt;
              &lt;!--[if mso | IE]&gt;
                  &lt;table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0""&gt;
                
        &lt;tr&gt;
      
            &lt;td
               class="""" style=""vertical-align:top;width:360px;""
            &gt;
          &lt;![endif]--&gt;
              &lt;div class=""mj-column-per-50 outlook-group-fix"" style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;""&gt;
                &lt;table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""vertical-align:top;"" width=""100%""&gt;
                  &lt;tr&gt;
                    &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;word-break:break-word;""&gt;
                      &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:16px;font-weight:400;line-height:24px;text-align:left;color:#444;""&gt; &lt;span style=""color:#666""&gt;Package&lt;/span&gt; &lt;br /&gt; &lt;span style=""font-weight:bold""&gt;{{PACKAGE_NAME}}&lt;/span&gt; &lt;/div&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                &lt;/table&gt;
              &lt;/div&gt;
              &lt;!--[if mso | IE]&gt;
            &lt;/td&gt;
          
            &lt;td
               class="""" style=""vertical-align:top;width:360px;""
            &gt;
          &lt;![endif]--&gt;
              &lt;div class=""mj-column-per-50 outlook-group-fix"" style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;""&gt;
                &lt;table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""vertical-align:top;"" width=""100%""&gt;
                  &lt;tr&gt;
                    &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;word-break:break-word;""&gt;
                      &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:16px;font-weight:400;line-height:24px;text-align:left;color:#444;""&gt; &lt;span style=""color:#666""&gt;No. of Employees&lt;/span&gt; &lt;br /&gt; &lt;span style=""font-weight:bold""&gt;{{HEADCOUNT}}&lt;/span&gt; &lt;/div&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                &lt;/table&gt;
              &lt;/div&gt;
              &lt;!--[if mso | IE]&gt;
            &lt;/td&gt;
          
        &lt;/tr&gt;
      
                  &lt;/table&gt;
                &lt;![endif]--&gt;
            &lt;/td&gt;
          &lt;/tr&gt;
        &lt;/tbody&gt;
      &lt;/table&gt;
    &lt;/div&gt;
    &lt;!--[if mso | IE]&gt;
          &lt;/td&gt;
        &lt;/tr&gt;
      &lt;/table&gt;
      
      &lt;table
         align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""" style=""width:720px;"" width=""720""
      &gt;
        &lt;tr&gt;
          &lt;td style=""line-height:0px;font-size:0px;mso-line-height-rule:exactly;""&gt;
      &lt;![endif]--&gt;
    &lt;div style=""Margin:0px auto;max-width:720px;""&gt;
      &lt;table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""width:100%;""&gt;
        &lt;tbody&gt;
          &lt;tr&gt;
            &lt;td style=""direction:ltr;font-size:0px;padding:20px 0;padding-bottom:0;padding-top:0;text-align:center;vertical-align:top;""&gt;
              &lt;!--[if mso | IE]&gt;
                  &lt;table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0""&gt;
                
        &lt;tr&gt;
      
            &lt;td
               class="""" style=""vertical-align:top;width:360px;""
            &gt;
          &lt;![endif]--&gt;
              &lt;div class=""mj-column-per-50 outlook-group-fix"" style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;""&gt;
                &lt;table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""vertical-align:top;"" width=""100%""&gt;
                  &lt;tr&gt;
                    &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;word-break:break-word;""&gt;
                      &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:16px;font-weight:400;line-height:24px;text-align:left;color:#444;""&gt; &lt;span style=""color:#666""&gt;per company per year&lt;/span&gt; &lt;br /&gt; &lt;span style=""font-weight:bold""&gt;{{PREMIUM_TOTAL}}&lt;/span&gt; &lt;/div&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                &lt;/table&gt;
              &lt;/div&gt;
              &lt;!--[if mso | IE]&gt;
            &lt;/td&gt;
          
            &lt;td
               class="""" style=""vertical-align:top;width:360px;""
            &gt;
          &lt;![endif]--&gt;
              &lt;div class=""mj-column-per-50 outlook-group-fix"" style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;""&gt;
                &lt;table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""vertical-align:top;"" width=""100%""&gt;
                  &lt;tr&gt;
                    &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;word-break:break-word;""&gt;
                      &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:16px;font-weight:400;line-height:24px;text-align:left;color:#444;""&gt; &lt;span style=""color:#666""&gt;per employee per year&lt;/span&gt; &lt;br /&gt; &lt;span style=""font-weight:bold""&gt;{{PREMIUM_PEREMPLOYEE}}&lt;/span&gt; &lt;/div&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                &lt;/table&gt;
              &lt;/div&gt;
              &lt;!--[if mso | IE]&gt;
            &lt;/td&gt;
          
        &lt;/tr&gt;
      
                  &lt;/table&gt;
                &lt;![endif]--&gt;
            &lt;/td&gt;
          &lt;/tr&gt;
        &lt;/tbody&gt;
      &lt;/table&gt;
    &lt;/div&gt;
    &lt;!--[if mso | IE]&gt;
          &lt;/td&gt;
        &lt;/tr&gt;
      &lt;/table&gt;
      
      &lt;table
         align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""" style=""width:720px;"" width=""720""
      &gt;
        &lt;tr&gt;
          &lt;td style=""line-height:0px;font-size:0px;mso-line-height-rule:exactly;""&gt;
      &lt;![endif]--&gt;
    &lt;div style=""Margin:0px auto;max-width:720px;""&gt;
      &lt;table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""width:100%;""&gt;
        &lt;tbody&gt;
          &lt;tr&gt;
            &lt;td style=""direction:ltr;font-size:0px;padding:20px 0;padding-bottom:10px;padding-top:0;text-align:center;vertical-align:top;""&gt;
              &lt;!--[if mso | IE]&gt;
                  &lt;table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0""&gt;
                
        &lt;tr&gt;
      
            &lt;td
               class="""" style=""vertical-align:top;width:720px;""
            &gt;
          &lt;![endif]--&gt;
              &lt;div class=""mj-column-per-100 outlook-group-fix"" style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;""&gt;
                &lt;table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""vertical-align:top;"" width=""100%""&gt;
                  &lt;tr&gt;
                    &lt;td style=""font-size:0px;padding:10px 25px;word-break:break-word;""&gt;
                      &lt;p style=""border-top:solid 1px #ea2a27;font-size:1;margin:0px auto;width:100%;""&gt; &lt;/p&gt;
                      &lt;!--[if mso | IE]&gt;
        &lt;table
           align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-top:solid 1px #ea2a27;font-size:1;margin:0px auto;width:670px;"" role=""presentation"" width=""670px""
        &gt;
          &lt;tr&gt;
            &lt;td style=""height:0;line-height:0;""&gt;
              &amp;nbsp;
            &lt;/td&gt;
          &lt;/tr&gt;
        &lt;/table&gt;
      &lt;![endif]--&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                &lt;/table&gt;
              &lt;/div&gt;
              &lt;!--[if mso | IE]&gt;
            &lt;/td&gt;
          
        &lt;/tr&gt;
      
                  &lt;/table&gt;
                &lt;![endif]--&gt;
            &lt;/td&gt;
          &lt;/tr&gt;
        &lt;/tbody&gt;
      &lt;/table&gt;
    &lt;/div&gt;
    &lt;!--[if mso | IE]&gt;
          &lt;/td&gt;
        &lt;/tr&gt;
      &lt;/table&gt;
      &lt;![endif]--&gt;
    &lt;!--LOOP_BENEFIT_START--&gt;
    &lt;!--[if mso | IE]&gt;
      &lt;table
         align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""" style=""width:720px;"" width=""720""
      &gt;
        &lt;tr&gt;
          &lt;td style=""line-height:0px;font-size:0px;mso-line-height-rule:exactly;""&gt;
      &lt;![endif]--&gt;
    &lt;div style=""Margin:0px auto;max-width:720px;""&gt;
      &lt;table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""width:100%;""&gt;
        &lt;tbody&gt;
          &lt;tr&gt;
            &lt;td style=""direction:ltr;font-size:0px;padding:20px 0;padding-bottom:0;padding-top:0;text-align:center;vertical-align:top;""&gt;
              &lt;!--[if mso | IE]&gt;
                  &lt;table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0""&gt;
                
        &lt;tr&gt;
      
            &lt;td
               class="""" style=""vertical-align:top;width:360px;""
            &gt;
          &lt;![endif]--&gt;
              &lt;div class=""mj-column-per-50 outlook-group-fix"" style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;""&gt;
                &lt;table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""vertical-align:top;"" width=""100%""&gt;
                  &lt;tr&gt;
                    &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;padding-top:0;padding-bottom:0;word-break:break-word;""&gt;
                      &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:16px;font-weight:400;line-height:24px;text-align:left;color:#444;""&gt; {{BENEFIT}} &lt;/div&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                &lt;/table&gt;
              &lt;/div&gt;
              &lt;!--[if mso | IE]&gt;
            &lt;/td&gt;
          
            &lt;td
               class="""" style=""vertical-align:top;width:360px;""
            &gt;
          &lt;![endif]--&gt;
              &lt;div class=""mj-column-per-50 outlook-group-fix"" style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;""&gt;
                &lt;table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" width=""100%""&gt;
                  &lt;tbody&gt;
                    &lt;tr&gt;
                      &lt;td style=""vertical-align:top;padding-bottom:10px;""&gt;
                        &lt;table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style="""" width=""100%""&gt;
                          &lt;tr&gt;
                            &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;padding-top:0;padding-bottom:0;word-break:break-word;""&gt;
                              &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:16px;font-weight:bold;line-height:24px;text-align:left;color:#444;""&gt; {{BENEFIT_OPTION}} &lt;/div&gt;
                            &lt;/td&gt;
                          &lt;/tr&gt;
                        &lt;/table&gt;
                      &lt;/td&gt;
                    &lt;/tr&gt;
                  &lt;/tbody&gt;
                &lt;/table&gt;
              &lt;/div&gt;
              &lt;!--[if mso | IE]&gt;
            &lt;/td&gt;
          
        &lt;/tr&gt;
      
                  &lt;/table&gt;
                &lt;![endif]--&gt;
            &lt;/td&gt;
          &lt;/tr&gt;
        &lt;/tbody&gt;
      &lt;/table&gt;
    &lt;/div&gt;
    &lt;!--[if mso | IE]&gt;
          &lt;/td&gt;
        &lt;/tr&gt;
      &lt;/table&gt;
      &lt;![endif]--&gt;
    &lt;!--LOOP_BENEFIT_END--&gt;
    &lt;!--[if mso | IE]&gt;
      &lt;table
         align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""" style=""width:720px;"" width=""720""
      &gt;
        &lt;tr&gt;
          &lt;td style=""line-height:0px;font-size:0px;mso-line-height-rule:exactly;""&gt;
      &lt;![endif]--&gt;
    &lt;div style=""Margin:0px auto;max-width:720px;""&gt;
      &lt;table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""width:100%;""&gt;
        &lt;tbody&gt;
          &lt;tr&gt;
            &lt;td style=""direction:ltr;font-size:0px;padding:20px 0;padding-top:0;text-align:center;vertical-align:top;""&gt;
              &lt;!--[if mso | IE]&gt;
                  &lt;table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0""&gt;
                
        &lt;tr&gt;
      
            &lt;td
               class="""" style=""vertical-align:top;width:720px;""
            &gt;
          &lt;![endif]--&gt;
              &lt;div class=""mj-column-per-100 outlook-group-fix"" style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;""&gt;
                &lt;table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""vertical-align:top;"" width=""100%""&gt;
                  &lt;tr&gt;
                    &lt;td style=""font-size:0px;padding:10px 25px;word-break:break-word;""&gt;
                      &lt;p style=""border-top:solid 1px #ea2a27;font-size:1;margin:0px auto;width:100%;""&gt; &lt;/p&gt;
                      &lt;!--[if mso | IE]&gt;
        &lt;table
           align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-top:solid 1px #ea2a27;font-size:1;margin:0px auto;width:670px;"" role=""presentation"" width=""670px""
        &gt;
          &lt;tr&gt;
            &lt;td style=""height:0;line-height:0;""&gt;
              &amp;nbsp;
            &lt;/td&gt;
          &lt;/tr&gt;
        &lt;/table&gt;
      &lt;![endif]--&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                &lt;/table&gt;
              &lt;/div&gt;
              &lt;!--[if mso | IE]&gt;
            &lt;/td&gt;
          
        &lt;/tr&gt;
      
                  &lt;/table&gt;
                &lt;![endif]--&gt;
            &lt;/td&gt;
          &lt;/tr&gt;
        &lt;/tbody&gt;
      &lt;/table&gt;
    &lt;/div&gt;
    &lt;!--[if mso | IE]&gt;
          &lt;/td&gt;
        &lt;/tr&gt;
      &lt;/table&gt;
      
      &lt;table
         align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""" style=""width:720px;"" width=""720""
      &gt;
        &lt;tr&gt;
          &lt;td style=""line-height:0px;font-size:0px;mso-line-height-rule:exactly;""&gt;
      &lt;![endif]--&gt;
    &lt;div style=""Margin:0px auto;max-width:720px;""&gt;
      &lt;table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""width:100%;""&gt;
        &lt;tbody&gt;
          &lt;tr&gt;
            &lt;td style=""direction:ltr;font-size:0px;padding:20px 0;padding-bottom:36px;padding-top:0;text-align:center;vertical-align:top;""&gt;
              &lt;!--[if mso | IE]&gt;
                  &lt;table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0""&gt;
        &lt;tr&gt;
            &lt;td
               class="""" style=""vertical-align:top;width:360px;""&gt;
          &lt;![endif]--&gt;
              &lt;div class=""mj-column-per-50 outlook-group-fix"" style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;""&gt;
                &lt;table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""vertical-align:top;"" width=""100%""&gt;
                  &lt;tr&gt;
                    &lt;td align=""left"" style=""font-size:0px;padding:5px 25px;word-break:break-word;""&gt;
                      &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:16px;font-weight:400;line-height:24px;text-align:left;color:#444;""&gt; &lt;span&gt;Technology powered by&amp;nbsp;&lt;/span&gt; &lt;img width=""100"" href=""https://cxagroup.com"" src=""https://mjml.io/assets/img/logo-small.png"" alt=""CXA Group"" style=""vertical-align: middle;""&gt;&lt;/img&gt;
                      &lt;/div&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                &lt;/table&gt;
              &lt;/div&gt;
              &lt;!--[if mso | IE]&gt;
            &lt;/td&gt;
          
            &lt;td
               class="""" style=""vertical-align:bottom;width:360px;""
            &gt;
          &lt;![endif]--&gt;
              &lt;div class=""mj-column-per-50 outlook-group-fix"" style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:bottom;width:100%;""&gt;
                &lt;table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""vertical-align:bottom;"" width=""100%""&gt;
                  &lt;tr&gt;
                    &lt;td align=""right"" style=""font-size:0px;padding:5px 25px;word-break:break-word;""&gt;
                      &lt;div style=""font-family:'Helvetica Neue', Arial, sans-serif;font-size:16px;font-weight:400;line-height:24px;text-align:right;color:#444;""&gt; Need help? &lt;a href=""""&gt;Contact Us&lt;/a&gt; &lt;/div&gt;
                    &lt;/td&gt;
                  &lt;/tr&gt;
                &lt;/table&gt;
              &lt;/div&gt;
              &lt;!--[if mso | IE]&gt;
            &lt;/td&gt;
        &lt;/tr&gt;
                  &lt;/table&gt;
                &lt;![endif]--&gt;
            &lt;/td&gt;
          &lt;/tr&gt;
        &lt;/tbody&gt;
      &lt;/table&gt;
    &lt;/div&gt;
    &lt;!--[if mso | IE]&gt;
          &lt;/td&gt;
        &lt;/tr&gt;
      &lt;/table&gt;
      &lt;![endif]--&gt;
  &lt;/div&gt;
&lt;/body&gt;

&lt;/html&gt;";
    }
}
