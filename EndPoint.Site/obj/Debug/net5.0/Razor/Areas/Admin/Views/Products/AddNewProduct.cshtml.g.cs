#pragma checksum "C:\Users\AMINSYSTEM\Desktop\project\MyProject\WebSite 1\WebSite.reza\EndPoint.Site\Areas\Admin\Views\Products\AddNewProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf9a14eda3d13ca0b98e6b5e2f192dd923c148f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Products_AddNewProduct), @"mvc.1.0.view", @"/Areas/Admin/Views/Products/AddNewProduct.cshtml")]
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
#line 1 "C:\Users\AMINSYSTEM\Desktop\project\MyProject\WebSite 1\WebSite.reza\EndPoint.Site\Areas\Admin\Views\_ViewImports.cshtml"
using EndPoint.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\AMINSYSTEM\Desktop\project\MyProject\WebSite 1\WebSite.reza\EndPoint.Site\Areas\Admin\Views\_ViewImports.cshtml"
using EndPoint.Site.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf9a14eda3d13ca0b98e6b5e2f192dd923c148f4", @"/Areas/Admin/Views/Products/AddNewProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87685c89e84078b3e134b89a928accf3d0f04a39", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Products_AddNewProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Category"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Sweetalert2/sweetalert2.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Sweetalert2/sweetalert2.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\AMINSYSTEM\Desktop\project\MyProject\WebSite 1\WebSite.reza\EndPoint.Site\Areas\Admin\Views\Products\AddNewProduct.cshtml"
  
    ViewData["Title"] = "AddNewProduct";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<section class=""basic-elements"">
    <div class=""row"">
        <div class=""col-sm-12"">
            <h2 class=""content-header"">فرم ثبت نام کاربر جدید</h2>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""card"">
                <div class=""card-header"">
                    <div class=""card-title-wrap bar-success"">
                        <h4 class=""card-title mb-0"">اطلاعات کاربر جدید را وارد نمایید</h4>
                    </div>
                </div>
                <div class=""card-body"">
                    <div class=""px-3"">
                        <div class=""form"">
                            <div class=""form-body"">
                                <div class=""row"">
                                    <div class=""col-xl-4 col-lg-6 col-md-12 mb-1"">
                                        <fieldset class=""form-group"">
                                            <label for=""basicInput"">نام محصول </label>
                        ");
            WriteLiteral(@"                    <input type=""text"" class=""form-control"" id=""Name"">
                                        </fieldset>
                                    </div>
                                    <div class=""col-xl-4 col-lg-6 col-md-12 mb-1"">
                                        <fieldset class=""form-group"">
                                            <label for=""basicInput""> برند </label>
                                            <input type=""text"" class=""form-control"" id=""Brand"">
                                        </fieldset>
                                    </div>
                                    <div class=""col-xl-4 col-lg-6 col-md-12 mb-1"">
                                        <fieldset class=""form-group"">
                                            <label for=""basicInput""> قیمت</label>
                                            <input type=""number"" class=""form-control"" id=""Price"">
                                        </fieldset>
                                ");
            WriteLiteral(@"    </div>
                                    <div class=""col-xl-4 col-lg-6 col-md-12 mb-1"">
                                        <fieldset class=""form-group"">
                                            <label for=""basicInput""> تعداد موجودی</label>
                                            <input type=""number"" class=""form-control"" id=""Inventory"">
                                        </fieldset>
                                    </div>
                                    <div class=""col-xl-4 col-lg-6 col-md-12 mb-1"">
                                        <fieldset class=""form-group"">
                                            <label for=""basicInput"">نمایش داده شود؟ </label>
                                            <input type=""checkbox"" class=""form-control"" id=""Displayed"">
                                        </fieldset>
                                    </div>
                                    <div class=""col-xl-4 col-lg-6 col-md-12 mb-1"">
                               ");
            WriteLiteral(@"         <fieldset class=""form-group"">
                                            <label for=""basicInput"">تصاویر </label>
                                            <input type=""file"" multiple class=""form-control"" accept=""image/*"" id=""Images"">
                                        </fieldset>
                                    </div>

                                    <div class=""col-xl-4 col-lg-6 col-md-12 mb-1"">
                                        <fieldset class=""form-group"">
                                            <label for=""basicInput"">دسته بندی </label>

                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf9a14eda3d13ca0b98e6b5e2f192dd923c148f49523", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 69 "C:\Users\AMINSYSTEM\Desktop\project\MyProject\WebSite 1\WebSite.reza\EndPoint.Site\Areas\Admin\Views\Products\AddNewProduct.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.Categories;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        </fieldset>
                                    </div>
                                    <div class=""col-xl-12 col-lg-12 col-md-12 mb-1"">
                                        <fieldset class=""form-group"">
                                            <label for=""basicInput""> توضیحات</label>
                                            <textarea id=""Description"" class=""form-control "" rows=""5""></textarea>
                                        </fieldset>
                                    </div>

                                    <hr />
                                    <hr />
                                    <div class=""col-xl-2 col-lg-6 col-md-12 mb-1"">
                                        <fieldset class=""form-group"">
                                            <label for=""basicInput""> نام ویژگی </label>
                                            <input type=""text"" class=""form-control"" id=""txtDisplayName"" placeholder=""نام ویژگی"" />
    ");
            WriteLiteral(@"                                    </fieldset>
                                    </div>

                                    <div class=""col-xl-2 col-lg-6 col-md-12 mb-1"">
                                        <fieldset class=""form-group"">
                                            <label for=""basicInput""> مقدار ویژگی </label>
                                            <input type=""text"" class=""form-control"" id=""txtValue"" placeholder=""مقدار ویژگی"" />
                                        </fieldset>
                                    </div>
                                    <div class=""col-xl-2 col-lg-6 col-md-12 mb-1"">
                                        <fieldset class=""form-group"">
                                            <br />
                                            <a class=""btn btn-success"" id=""btnAddFeatures"">افزودن</a>
                                        </fieldset>
                                    </div>

                                    <br class=""cl");
            WriteLiteral(@"ear"" />

                                    <table id=""tbl_Features"" class=""col-md-12 table table-bordered table-hover  table-condensed table-responsive"">
                                        <thead>
                                            <tr>
                                                <th>
                                                    نام ویژگی
                                                </th>
                                                <th>
                                                    مقدار ویژگی
                                                </th>
                                                <th>

                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <div class=""col-xl-12 col-lg-12 col-md-12 mb-1"">
                   ");
            WriteLiteral(@"                     <fieldset class=""form-group"">
                                            <br />
                                            <a id=""btnAddProduct"" class=""btn btn-success col-md-12""> افزودن محصول  </a>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>


");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bf9a14eda3d13ca0b98e6b5e2f192dd923c148f415002", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf9a14eda3d13ca0b98e6b5e2f192dd923c148f416181", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <script>

        $(""#btnAddFeatures"").on(""click"", function () {

            var txtDisplayName = $(""#txtDisplayName"").val();
            var txtValue = $(""#txtValue"").val();

            if (txtDisplayName == """" || txtValue == """") {
                swal.fire(
                    'هشدار!',
                    ""نام و مقدار را باید وارد کنید"",
                    'warning'
                );
            }
            else {
                $('#tbl_Features tbody').append('<tr> <td>' + txtDisplayName + '</td>  <td>' + txtValue + '</td> <td> <a class=""idFeatures btnDelete btn btn-danger""> حذف </a> </td> </tr>');
                $(""#txtDisplayName"").val('');
                $(""#txtValue"").val('');
            }
        });

        $(""#tbl_Features"").on('click', '.idFeatures', function () {
            $(this).closest('tr').remove();
        });



        $('#btnAddProduct').on('click', function () {

            var data = new FormData();

            //دریافت مقادیر از تک");
                WriteLiteral(@"س باکس ها و....
            data.append(""Name"", $(""#Name"").val());
            data.append(""Brand"", $(""#Brand"").val());
            data.append(""Price"", $(""#Price"").val());
            data.append(""Inventory"", $(""#Inventory"").val());
            data.append(""Displayed"", $(""#Displayed"").attr(""checked"") ? true : false);
            data.append(""CategoryId"", $('#Category').find('option:selected').val());
            data.append(""Description"", $(""#Description"").val());


            //دریافت عکس های انتخاب شده توسط کاربر و قرار دادن عکس ها در متغیر data
            var productImages = document.getElementById(""Images"");

            if (productImages.files.length > 0) {
                for (var i = 0; i < productImages.files.length; i++) {
                    data.append('Images-' + i, productImages.files[i]);
                }
            }

            //دریافت ویژگی های محصول از جدول
            var dataFeaturesViewModel = $('#tbl_Features tr:gt(0)').map(function () {
                return");
                WriteLiteral(@" {
                    DisplayName: $(this.cells[0]).text(),
                    Value: $(this.cells[1]).text(),
                };
            }).get();

            $.each(dataFeaturesViewModel, function (i, val) {
                data.append('[' + i + '].DisplayName', val.DisplayName);
                data.append('[' + i + '].Value', val.Value);

            });





            // ارسال اطلاعات بع کنترلر
            var ajaxRequest = $.ajax({
                type: ""POST"",
                url: ""AddNewProduct"",
                contentType: false,
                processData: false,
                data: data,
                success: function (data) {

                    if (data.isSuccess == true) {

                        swal.fire(
                            'موفق!',
                            data.message,
                            'success'
                        ).then(function (isConfirm) {
                            window.location.href = ""/Admin/Products/"";
");
                WriteLiteral(@"
                        });
                    }
                    else {

                        swal.fire(
                            'هشدار!',
                            data.message,
                            'warning'
                        );
                    }

                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.status);
                    alert(thrownError);
                }

            });

            ajaxRequest.done(function (xhr, textStatus) {
                // Do other operation
            });
        });

    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
