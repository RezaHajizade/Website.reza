#pragma checksum "C:\Users\AMINSYSTEM\Desktop\project\MyProject\WebSite 1\WebSite.reza\EndPoint.Site\Views\Authentication\SignIn.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8cc48a28b5e5834de9b47eb5b006a4463a33262"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Authentication_SignIn), @"mvc.1.0.view", @"/Views/Authentication/SignIn.cshtml")]
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
#line 1 "C:\Users\AMINSYSTEM\Desktop\project\MyProject\WebSite 1\WebSite.reza\EndPoint.Site\Views\_ViewImports.cshtml"
using EndPoint.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\AMINSYSTEM\Desktop\project\MyProject\WebSite 1\WebSite.reza\EndPoint.Site\Views\_ViewImports.cshtml"
using EndPoint.Site.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8cc48a28b5e5834de9b47eb5b006a4463a33262", @"/Views/Authentication/SignIn.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87685c89e84078b3e134b89a928accf3d0f04a39", @"/Views/_ViewImports.cshtml")]
    public class Views_Authentication_SignIn : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!--");
#nullable restore
#line 2 "C:\Users\AMINSYSTEM\Desktop\project\MyProject\WebSite 1\WebSite.reza\EndPoint.Site\Views\Authentication\SignIn.cshtml"
      
    ViewData["Title"] = "Signin";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!DOCTYPE html>
<html lang=""fa"" dir=""rtl"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>ثبت نام</title>-->
    <!-- font---------------------------------------->
    <!--<link rel=""stylesheet"" href=""~/SiteTemplate/assets/css/vendor/font-awesome.min.css"">
    <link rel=""stylesheet"" href=""~/SiteTemplate/assets/css/vendor/materialdesignicons.css"">-->
    <!-- plugin-------------------------------------->
    <!--<link rel=""stylesheet"" href=""~/SiteTemplate/assets/css/vendor/bootstrap.css"">
    <link rel=""stylesheet"" href=""~/SiteTemplate/assets/css/vendor/owl.carousel.min.css"">
    <link rel=""stylesheet"" href=""~/SiteTemplate/assets/css/vendor/noUISlider.min.css"">-->
    <!-- main-style---------------------------------->
    <!--<link rel=""stylesheet"" href=""~/SiteTemplate/assets/css/main.css"">
</head>
<body>-->

    <!-- login----------------------------------->
    <!--<div class=""container"">
        <div class=""row"">
            WriteLiteral(@"
            <div class=""col-lg"">
                <section class=""page-account-box"">
                    <div class=""col-lg-6 col-md-6 col-xs-12 mx-auto"">
                        <div class=""ds-userlogin"">
                            <a href=""#"" class=""account-box-logo"">digismart</a>
                            <div class=""account-box"">
                                <div class=""account-box-headline"">
                                    <a href=""#"" class=""login-ds active"">
                                        <span class=""title"">ورود</span>
                                        <span class=""sub-title"">به فروشگاه رضا</span>
                                    </a>
                                    <a href=""~/authentication/signup"" class=""register-ds"">
                                        <span class=""title"">ثبت نام</span>
                                        <span class=""sub-title"">در فروشگاه رضا</span>
                                    </a>
                                </div>");
            WriteLiteral(@"
                                <div class=""Login-to-account mt-4"">
                                    <div class=""account-box-content"">
                                        <h4>ورود به حساب کاربری</h4>
                                        <form   class=""form-account text-right"">
                                            <div class=""form-account-title"">
                                                <label for=""email-phone"">ایمیل  </label>
                                                <input type=""text"" class=""number-email-input"" id=""Email"" name=""email-account"">
                                            </div>
                                            <div class=""form-account-title"">
                                                <label for=""password"">رمز عبور</label>
                                                <a href=""#"" class=""account-link-password"">رمز خود را فراموش کرده ام</a>
                                                <input type=""password"" class=""password-input"" i");
            WriteLiteral(@"d=""Password"">
                                            </div>
                                            <div class=""form-auth-row"">
                                                <label for=""#"" class=""ui-checkbox mt-1"">
                                                    <input type=""checkbox"" value=""1"" name=""login"" id=""remember"">
                                                    <span class=""ui-checkbox-check""></span>
                                                </label>
                                                <label for=""remember"" class=""remember-me mr-0"">مرا به خاطر بسپار</label>
                                            </div>
                                            <div class=""form-row-account"">
                                                <a onclick=""Login()"" class=""btn btn-primary btn-login"">ورود به فروشگاه رضا  </a>
                                            </div>
                                        </form>
                                    </div>
    ");
            WriteLiteral(@"                            </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>-->
    <!-- login----------------------------------->
    <!-- scroll_Progress------------------------->
    <!--<div class=""progress-wrap"">
        <svg class=""progress-circle svg-content"" width=""100%"" height=""100%"" viewBox=""-1 -1 102 102"">
            <path d=""M50,1 a49,49 0 0,1 0,98 a49,49 0 0,1 0,-98"" />
        </svg>
    </div>-->
    <!-- scroll_Progress------------------------->

<!--</body>-->
<!-- file js---------------------------------------------------->
<!--<script src=""~/SiteTemplate/assets/js/vendor/jquery-3.2.1.min.js""></script>
<script src=""~/SiteTemplate/assets/js/vendor/bootstrap.js""></script>-->
<!-- plugin----------------------------------------------------->
<!--<script src=""~/SiteTemplate/assets/js/vendor/owl.carousel.min.js""></script>
<script src=""~/SiteTemplate/ass");
            WriteLiteral(@"ets/js/vendor/jquery.countdown.js""></script>
<script src=""~/SiteTemplate/assets/js/vendor/ResizeSensor.min.js""></script>
<script src=""~/SiteTemplate/assets/js/vendor/theia-sticky-sidebar.min.js""></script>
<script src=""~/SiteTemplate/assets/js/vendor/wNumb.js""></script>
<script src=""~/SiteTemplate/assets/js/vendor/nouislider.min.js""></script>-->
<!-- main js---------------------------------------------------->
<!--<script src=""~/SiteTemplate/assets/js/main.js""></script>


<link href=""~/Sweetalert2/sweetalert2.min.css"" rel=""stylesheet"" />
<script src=""~/Sweetalert2/sweetalert2.min.js""></script>


<script>
    function Login() {
        var Email = $(""#Email"").val();
        var Password = $(""#Password"").val();
        var postData = {
            'Email': Email,
            'Password': Password,
        };
        $.ajax({
            contentType: 'application/x-www-form-urlencoded',
            dataType: 'json',
            type: ""POST"",
            url: ""Signin"",
            data: po");
            WriteLiteral(@"stData,
            success: function (data) {
                if (data.isSuccess == true) {
                    swal.fire(
                        'موفق!',
                        data.message,
                        'success'
                    ).then(function (isConfirm) {
                        window.location.replace(""/"");
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
            error: function (request, status, error) {
                swal.fire(
                    'هشدار!',
                    request.responseText,
                    'warning'
                );
            }
        });
    }
</script>
</html>-->

                    ");
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