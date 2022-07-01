#pragma checksum "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13507e286eef158d75f535b70f71ba0b8c515480"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_listOfUsers), @"mvc.1.0.view", @"/Views/Admin/listOfUsers.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\_ViewImports.cshtml"
using BIA_Cinema_Ticket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\_ViewImports.cshtml"
using BIA_Cinema_Ticket.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13507e286eef158d75f535b70f71ba0b8c515480", @"/Views/Admin/listOfUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ae34280c174cbec5a0a3988b56fd2bc0bd852ee", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_listOfUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
  
    Layout = "_Admin";
    List<User> users = ViewBag.users;
    string[] tableHeaders = new string[]{
        "Name","Surname","Nickname","Gender","Email","Phone Number","Birthday","User Type","Delete","Set Admin or User"
    };
    bool flag = false;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container-fluid px-4\">\r\n    <p class=\"text-danger\">");
#nullable restore
#line 10 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                      Write(ViewBag.errorMassage);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
    <div class=""card mb-4 mt-4"">
        <div class=""card-header"">
            <i class=""fas fa-table me-1""></i>
            <b>List Of Users</b>
        </div>
        <div class=""card-body"">
            <div class=""table"">
                <table id=""datatablesSimple"">
                    <thead>
                        <tr>
");
#nullable restore
#line 21 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                             foreach (var table_header in tableHeaders)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <th>");
#nullable restore
#line 23 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                               Write(table_header);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 24 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 28 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                         foreach (var user in users)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                             if (flag != false)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 33 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                   Write(user.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 34 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                   Write(user.surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 35 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                   Write(user.nickName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 36 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                     if (user.gender == true)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>Male</td>\r\n");
#nullable restore
#line 39 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>Female</td>\r\n");
#nullable restore
#line 43 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>");
#nullable restore
#line 44 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                   Write(user.email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 45 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                   Write(user.phoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 46 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                      
                                        DateTime date = user.birthday;
                                        string birthday = date.ToString("yyyy-MM-dd");
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>");
#nullable restore
#line 50 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                   Write(birthday);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 51 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                     if (user.userType == true)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>Admin</td>\r\n");
#nullable restore
#line 54 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>User</td>\r\n");
#nullable restore
#line 58 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13507e286eef158d75f535b70f71ba0b8c51548012312", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2607, "~/user/DeleteUser?user_ID=", 2607, 26, true);
#nullable restore
#line 60 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
AddHtmlAttributeValue("", 2633, user.user_ID, 2633, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n");
#nullable restore
#line 63 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                         if (user.userType == true)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13507e286eef158d75f535b70f71ba0b8c51548014575", async() => {
                WriteLiteral("Set User");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2947, "~/user/SetUser?user_ID=", 2947, 23, true);
#nullable restore
#line 65 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
AddHtmlAttributeValue("", 2970, user.user_ID, 2970, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 66 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13507e286eef158d75f535b70f71ba0b8c51548016768", async() => {
                WriteLiteral("Set Admin");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3219, "~/user/SetAdmin?user_ID=", 3219, 24, true);
#nullable restore
#line 69 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
AddHtmlAttributeValue("", 3243, user.user_ID, 3243, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 70 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 74 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                            }
                            else
                            {
                                flag = true;
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "C:\Users\arman.celik\Source\Repos\armancelik\BIA-Cinema-Ticket-System\BIA-Cinema-Ticket\BIA-Cinema-Ticket\Views\Admin\listOfUsers.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
