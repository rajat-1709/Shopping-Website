#pragma checksum "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "441591066f9996b1d7bbe5bfd8a50419247b1c98"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AllOrdersDetails), @"mvc.1.0.view", @"/Views/Admin/AllOrdersDetails.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\_ViewImports.cshtml"
using sampleshopping1frontend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\_ViewImports.cshtml"
using sampleshopping1frontend.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"441591066f9996b1d7bbe5bfd8a50419247b1c98", @"/Views/Admin/AllOrdersDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d9ba533e4bd7a638871bf5558ab6ab059dc0343", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AllOrdersDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<sampleshopping1frontend.Models.Orderdetails>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
  
    ViewData["Title"] = "AllOrdersDetails";
    Layout = "_adminlayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>All Orders Details</h1>\r\n\r\n<table class=\"table table-striped\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.orderid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.uname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.productid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Productname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Productqty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.productTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.productorderdate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 35 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.deliverydate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 41 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.orderid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 47 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.uname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 50 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.productid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 53 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.Productname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 56 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.Productqty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                $");
#nullable restore
#line 59 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
            Write(Html.DisplayFor(modelItem => item.productTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 62 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.productorderdate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 65 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.deliverydate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n");
            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 73 "C:\Users\Admin\Desktop\Test Projects v1\sampleshopping1frontend\Views\Admin\AllOrdersDetails.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<sampleshopping1frontend.Models.Orderdetails>> Html { get; private set; }
    }
}
#pragma warning restore 1591