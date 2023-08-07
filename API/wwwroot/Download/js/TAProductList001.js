
function onTopPage() {
    $('html, body').animate({ scrollTop: 0 }, 'slow');
}
function onMenuAboutUsSubOpen() {
    document.getElementById("MenuBrandSub").hidden = true;
    document.getElementById("MenuProductSub").hidden = true;
    document.getElementById("MenuCustomSub").hidden = true;

    document.getElementById("MenuBrand").className = '';
    document.getElementById("MenuBrand").className = 'block_item_first';
    document.getElementById("MenuProduct").className = '';
    document.getElementById("MenuProduct").className = 'block_item_first';
    document.getElementById("MenuCustom").className = '';
    document.getElementById("MenuCustom").className = 'block_item_first';

    var menuAboutUsSubHidden = document.getElementById("MenuAboutUsSub").hidden;
    if (menuAboutUsSubHidden) {
        document.getElementById("MenuAboutUsSub").hidden = false;
        document.getElementById("MenuAboutUs").className = '';
        document.getElementById("MenuAboutUs").className = 'block_item_first menu-active-xl';
    }
    else {
        document.getElementById("MenuAboutUsSub").hidden = true;
        document.getElementById("MenuAboutUs").className = '';
        document.getElementById("MenuAboutUs").className = 'block_item_first';
    }
}
function onMenuAboutUsSubClose() {
    var Element = document.getElementById("MenuAboutUs");
    Element.classList.remove("menu-active-xl");
    var ElementSub = document.getElementById("MenuAboutUsSub");
    ElementSub.hidden = true;
}
function onMenuCustomSubOpen() {
    document.getElementById("MenuBrandSub").hidden = true;
    document.getElementById("MenuProductSub").hidden = true;
    document.getElementById("MenuAboutUsSub").hidden = true;

    document.getElementById("MenuBrand").className = '';
    document.getElementById("MenuBrand").className = 'block_item_first';
    document.getElementById("MenuProduct").className = '';
    document.getElementById("MenuProduct").className = 'block_item_first';
    document.getElementById("MenuAboutUs").className = '';
    document.getElementById("MenuAboutUs").className = 'block_item_first';

    var menuCustomSubHidden = document.getElementById("MenuCustomSub").hidden;
    if (menuCustomSubHidden) {
        document.getElementById("MenuCustomSub").hidden = false;
        document.getElementById("MenuCustom").className = '';
        document.getElementById("MenuCustom").className = 'block_item_first menu-active-xl';
    }
    else {
        document.getElementById("MenuCustomSub").hidden = true;
        document.getElementById("MenuCustom").className = '';
        document.getElementById("MenuCustom").className = 'block_item_first';
    }
}
function onMenuCustomSubClose() {
    var Element = document.getElementById("MenuCustom");
    Element.classList.remove("menu-active-xl");
    var ElementSub = document.getElementById("MenuCustomSub");
    ElementSub.hidden = true;
}
function onMenuProductSubOpen() {
    document.getElementById("MenuBrandSub").hidden = true;
    document.getElementById("MenuCustomSub").hidden = true;
    document.getElementById("MenuAboutUsSub").hidden = true;

    document.getElementById("MenuBrand").className = '';
    document.getElementById("MenuBrand").className = 'block_item_first';
    document.getElementById("MenuCustom").className = '';
    document.getElementById("MenuCustom").className = 'block_item_first';
    document.getElementById("MenuAboutUs").className = '';
    document.getElementById("MenuAboutUs").className = 'block_item_first';

    var menuProductSubHidden = document.getElementById("MenuProductSub").hidden;
    if (menuProductSubHidden) {
        document.getElementById("MenuProductSub").hidden = false;
        document.getElementById("MenuProduct").className = '';
        document.getElementById("MenuProduct").className = 'block_item_first menu-active-xl';
    }
    else {
        document.getElementById("MenuProductSub").hidden = true;
        document.getElementById("MenuProduct").className = '';
        document.getElementById("MenuProduct").className = 'block_item_first';
    }
}
function onMenuProductSubClose() {
    var Element = document.getElementById("MenuProduct");
    Element.classList.remove("menu-active-xl");
    var ElementSub = document.getElementById("MenuProductSub");
    ElementSub.hidden = true;
}
function onMenuBrandSubOpen() {
    document.getElementById("MenuProductSub").hidden = true;
    document.getElementById("MenuCustomSub").hidden = true;
    document.getElementById("MenuAboutUsSub").hidden = true;

    document.getElementById("MenuProduct").className = '';
    document.getElementById("MenuProduct").className = 'block_item_first';
    document.getElementById("MenuCustom").className = '';
    document.getElementById("MenuCustom").className = 'block_item_first';
    document.getElementById("MenuAboutUs").className = '';
    document.getElementById("MenuAboutUs").className = 'block_item_first';

    var menuBrandSubHidden = document.getElementById("MenuBrandSub").hidden;
    if (menuBrandSubHidden) {
        document.getElementById("MenuBrandSub").hidden = false;
        document.getElementById("MenuBrand").className = '';
        document.getElementById("MenuBrand").className = 'block_item_first menu-active-xl';
    }
    else {
        document.getElementById("MenuBrandSub").hidden = true;
        document.getElementById("MenuBrand").className = '';
        document.getElementById("MenuBrand").className = 'block_item_first';
    }
}
function onMenuBrandSubClose() {
    var Element = document.getElementById("MenuBrand");
    Element.classList.remove("menu-active-xl");
    var ElementSub = document.getElementById("MenuBrandSub");
    ElementSub.hidden = true;
}
function onMenuCollectionsShow() {
    var Element = document.getElementById("MenuCollections");
    Element.classList.add("active");
    var ElementSub = document.getElementById("MenuCollectionsSub");
    ElementSub.removeAttribute("hidden");

    Element = document.getElementById("MenuDesigners");
    Element.classList.remove("active");
    ElementSub = document.getElementById("MenuDesignersSub");
    ElementSub.hidden = true;
}
function onMenuDesignersShow() {
    var Element = document.getElementById("MenuDesigners");
    Element.classList.add("active");
    var ElementSub = document.getElementById("MenuDesignersSub");
    ElementSub.removeAttribute("hidden");

    Element = document.getElementById("MenuCollections");
    Element.classList.remove("active");
    ElementSub = document.getElementById("MenuCollectionsSub");
    ElementSub.hidden = true;
}
function onSlides001PREV() {
    var width = window.innerWidth - 500;
    width = width * -1;
    var $last = $('#Slides001 div.swiper-slide:last');
    $last.remove().css({ 'margin-left': width });
    $('#Slides001 div.swiper-slide:first').before($last);
    $last.animate({ 'margin-left': '0px' }, 300);
}
function onSlides001NEXT() {
    var width = window.innerWidth - 500;
    width = width * -1;
    var $first = $('#Slides001 div.swiper-slide:first');
    $first.animate({ 'margin-left': width }, 300, function () {
        $first.remove().css({ 'margin-left': '0px' });
        $('#Slides001 div.swiper-slide:last').after($first);
    });
}
function onSlides001InternationalPREV() {
    var width = window.innerWidth - 500;
    width = width * -1;
    var $last = $('#Slides001International div.swiper-slide:last');
    $last.remove().css({ 'margin-left': width });
    $('#Slides001International div.swiper-slide:first').before($last);
    $last.animate({ 'margin-left': '0px' }, 300);
}
function onSlides001InternationalNEXT() {
    var width = window.innerWidth - 500;
    width = width * -1;
    var $first = $('#Slides001International div.swiper-slide:first');
    $first.animate({ 'margin-left': width }, 300, function () {
        $first.remove().css({ 'margin-left': '0px' });
        $('#Slides001International div.swiper-slide:last').after($first);
    });
}
function onSlides002PREV() {
    var width = window.innerWidth - 500;
    width = width * -1;
    var $last = $('#Slides002 div.swiper-slide:last');
    $last.remove().css({ 'margin-left': width });
    $('#Slides002 div.swiper-slide:first').before($last);
    $last.animate({ 'margin-left': '0px' }, 300);
}
function onSlides002NEXT() {
    var width = window.innerWidth - 500;
    width = width * -1;
    var $first = $('#Slides002 div.swiper-slide:first');
    $first.animate({ 'margin-left': width }, 300, function () {
        $first.remove().css({ 'margin-left': '0px' });
        $('#Slides002 div.swiper-slide:last').after($first);
    });
}
function onSlides002InternationalPREV() {
    var width = window.innerWidth - 500;
    width = width * -1;
    var $last = $('#Slides002International div.swiper-slide:last');
    $last.remove().css({ 'margin-left': width });
    $('#Slides002International div.swiper-slide:first').before($last);
    $last.animate({ 'margin-left': '0px' }, 300);
}
function onSlides002InternationalNEXT() {
    var width = window.innerWidth - 500;
    width = width * -1;
    var $first = $('#Slides002International div.swiper-slide:first');
    $first.animate({ 'margin-left': width }, 300, function () {
        $first.remove().css({ 'margin-left': '0px' });
        $('#Slides002International div.swiper-slide:last').after($first);
    });
}
function onSlides003PREV() {
    var width = window.innerWidth - 100;
    width = width * -1;
    var $last = $('#Slides003 div.swiper-slide:last');
    $last.remove().css({ 'margin-left': width });
    $('#Slides003 div.swiper-slide:first').before($last);
    $last.animate({ 'margin-left': '0px' }, 300);
}
function onSlides003NEXT() {
    var width = window.innerWidth - 100;
    width = width * -1;
    var $first = $('#Slides003 div.swiper-slide:first');
    $first.animate({ 'margin-left': width }, 300, function () {
        $first.remove().css({ 'margin-left': '0px' });
        $('#Slides003 div.swiper-slide:last').after($first);
    });
}
function onSlides004PREV() {
    var width = window.innerWidth - 100;
    width = width * -1;
    var $last = $('#Slides004 div.swiper-slide:last');
    $last.remove().css({ 'margin-left': width });
    $('#Slides004 div.swiper-slide:first').before($last);
    $last.animate({ 'margin-left': '0px' }, 300);
}
function onSlides004NEXT() {
    var width = window.innerWidth - 100;
    width = width * -1;
    var $first = $('#Slides004 div.swiper-slide:first');
    $first.animate({ 'margin-left': width }, 300, function () {
        $first.remove().css({ 'margin-left': '0px' });
        $('#Slides004 div.swiper-slide:last').after($first);
    });
}
function onMenuBrandTheodoreAlexanderClick() {
    document.getElementById("MenuBrandTheodoreAlexander").hidden = true;
    document.getElementById("MenuBrandSALONE").hidden = true;
    document.getElementById("MenuBrandTAStudio").hidden = true;
    document.getElementById("MenuBrandTAAccents").hidden = true;
    document.getElementById("MenuBrandLaurent").hidden = true;

    document.getElementById("MenuBrandSALONESub").style.opacity = 0.5;
    document.getElementById("MenuBrandTAStudioSub").style.opacity = 0.5;
    document.getElementById("MenuBrandTAAccentsSub").style.opacity = 0.5;
    document.getElementById("MenuBrandLaurentSub").style.opacity = 0.5;

    document.getElementById("MenuBrandTheodoreAlexanderSub").style.opacity = 1;
    document.getElementById("MenuBrandTheodoreAlexander").hidden = false;
}
function onMenuBrandSALONEClick() {
    document.getElementById("MenuBrandTheodoreAlexander").hidden = true;
    document.getElementById("MenuBrandSALONE").hidden = true;
    document.getElementById("MenuBrandTAStudio").hidden = true;
    document.getElementById("MenuBrandTAAccents").hidden = true;
    document.getElementById("MenuBrandLaurent").hidden = true;

    document.getElementById("MenuBrandTheodoreAlexanderSub").style.opacity = 0.5;
    document.getElementById("MenuBrandTAStudioSub").style.opacity = 0.5;
    document.getElementById("MenuBrandTAAccentsSub").style.opacity = 0.5;
    document.getElementById("MenuBrandLaurentSub").style.opacity = 0.5;

    document.getElementById("MenuBrandSALONESub").style.opacity = 1;
    document.getElementById("MenuBrandSALONE").hidden = false;
}
function onMenuBrandTAStudioClick() {
    document.getElementById("MenuBrandTheodoreAlexander").hidden = true;
    document.getElementById("MenuBrandSALONE").hidden = true;
    document.getElementById("MenuBrandTAStudio").hidden = true;
    document.getElementById("MenuBrandTAAccents").hidden = true;
    document.getElementById("MenuBrandLaurent").hidden = true;

    document.getElementById("MenuBrandTheodoreAlexanderSub").style.opacity = 0.5;
    document.getElementById("MenuBrandSALONESub").style.opacity = 0.5;
    document.getElementById("MenuBrandTAAccentsSub").style.opacity = 0.5;
    document.getElementById("MenuBrandLaurentSub").style.opacity = 0.5;

    document.getElementById("MenuBrandTAStudioSub").style.opacity = 1;
    document.getElementById("MenuBrandTAStudio").hidden = false;
}
function onMenuBrandTAAccentsClick() {
    document.getElementById("MenuBrandTheodoreAlexander").hidden = true;
    document.getElementById("MenuBrandSALONE").hidden = true;
    document.getElementById("MenuBrandTAStudio").hidden = true;
    document.getElementById("MenuBrandTAAccents").hidden = true;
    document.getElementById("MenuBrandLaurent").hidden = true;

    document.getElementById("MenuBrandTheodoreAlexanderSub").style.opacity = 0.5;
    document.getElementById("MenuBrandSALONESub").style.opacity = 0.5;
    document.getElementById("MenuBrandTAStudioSub").style.opacity = 0.5;
    document.getElementById("MenuBrandLaurentSub").style.opacity = 0.5;

    document.getElementById("MenuBrandTAAccentsSub").style.opacity = 1;
    document.getElementById("MenuBrandTAAccents").hidden = false;
}
function onMenuBrandLaurentClick() {
    document.getElementById("MenuBrandTheodoreAlexander").hidden = true;
    document.getElementById("MenuBrandSALONE").hidden = true;
    document.getElementById("MenuBrandTAStudio").hidden = true;
    document.getElementById("MenuBrandTAAccents").hidden = true;
    document.getElementById("MenuBrandLaurent").hidden = true;

    document.getElementById("MenuBrandTheodoreAlexanderSub").style.opacity = 0.5;
    document.getElementById("MenuBrandSALONESub").style.opacity = 0.5;
    document.getElementById("MenuBrandTAStudioSub").style.opacity = 0.5;
    document.getElementById("MenuBrandTAAccentsSub").style.opacity = 0.5;

    document.getElementById("MenuBrandLaurentSub").style.opacity = 1;
    document.getElementById("MenuBrandLaurent").hidden = false;
}
function onEmailSubscribe() {
    var emailSubscribe = document.getElementById("EmailSubscribe").value;
    var url = "http://api-test.theodorealexander.com/api/Common/SubcribeEmail";
    var data = {
        Email: emailSubscribe
    };
    var json = JSON.stringify(data);
    $.ajax({
        type: "POST",
        url: url,
        data: json,
        headers: {
            "Ip_Address": '172.18.3.74',
            "API_KEY": 'X-some-key',
            'Authorization': ''
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
        },
        error: function (err) {
        }
    });
}

function onCheckUS() {
    var url = "http://ip-api.com/json";
    $.ajax({
        url: url,
        type: 'GET',
        success: function (data) {
            if (data.countryCode == 'US') {
                onViewUS();
            }
            else {
                onViewInternational();
            }
        },
        error: function (err) {
        }
    });
}

function onViewUS() {
    window.localStorage.setItem('Region', 'TAUS');
    document.getElementById("MenuBrandSALONESub").hidden = true;
    document.getElementById("MenuBrandSALONEMobile").hidden = true;
    document.getElementById("LaurentInternational").hidden = true;
    document.getElementById("MenuBrandSALONEImageInternational").hidden = true;
    document.getElementById("MenuBrandTAStudioImageInternational").hidden = true;
    document.getElementById("MenuBrandTAAccentsImageInternational").hidden = true;
    document.getElementById("ProductListProductsInternational").hidden = true;
    document.getElementById("MenuLeftInternational").hidden = true;
    document.getElementById("ProductListInternationalResults").hidden = true;

    document.getElementById("MenuBrandTAAccentsSub").hidden = false;
    document.getElementById("MenuBrandTAStudioMobile").hidden = false;
    document.getElementById("LaurentUS").hidden = false;
    document.getElementById("MenuBrandSALONEImageUS").hidden = false;
    document.getElementById("TAStudioFrenzyUS").hidden = false;
    document.getElementById("TAStudioHolliUS").hidden = false;
    document.getElementById("TAStudioFrenzyUSMobile").hidden = false;
    document.getElementById("TAStudioHolliUSMobile").hidden = false;
    document.getElementById("MenuBrandTAStudioImageUS").hidden = false;
    document.getElementById("MenuBrandTAAccentsImageUS").hidden = false;
    document.getElementById("ProductListProductsUS").hidden = false;
    document.getElementById("MenuLeftUS").hidden = false;
    document.getElementById("ProductListUSResults").hidden = false;
    document.getElementById("ProductListIsStocked").hidden = false;
}
function onViewInternational() {
    window.localStorage.setItem('Region', 'International');
    document.getElementById("MenuBrandSALONESub").hidden = false;
    document.getElementById("MenuBrandSALONEMobile").hidden = false;
    document.getElementById("LaurentInternational").hidden = false;
    document.getElementById("MenuBrandSALONEImageInternational").hidden = false;
    document.getElementById("MenuBrandTAStudioImageInternational").hidden = false;
    document.getElementById("MenuBrandTAAccentsImageInternational").hidden = false;
    document.getElementById("ProductListProductsInternational").hidden = false;
    document.getElementById("MenuLeftInternational").hidden = false;
    document.getElementById("ProductListInternationalResults").hidden = false;

    document.getElementById("MenuBrandTAAccentsSub").hidden = true;
    document.getElementById("MenuBrandTAStudioMobile").hidden = true;
    document.getElementById("LaurentUS").hidden = true;
    document.getElementById("MenuBrandSALONEImageUS").hidden = true;
    document.getElementById("TAStudioFrenzyUS").hidden = true;
    document.getElementById("TAStudioHolliUS").hidden = true;
    document.getElementById("TAStudioFrenzyUSMobile").hidden = true;
    document.getElementById("TAStudioHolliUSMobile").hidden = true;
    document.getElementById("MenuBrandTAStudioImageUS").hidden = true;
    document.getElementById("MenuBrandTAAccentsImageUS").hidden = true;
    document.getElementById("ProductListProductsUS").hidden = true;
    document.getElementById("MenuLeftUS").hidden = true;
    document.getElementById("ProductListUSResults").hidden = true;
    document.getElementById("ProductListIsStocked").hidden = true;
}
function onInitializationUser() {
    window.localStorage.setItem('SortBy', '1');
    document.getElementById("HeaderCart").hidden = true;
    document.getElementById("HeaderUser").hidden = true;
    document.getElementById("HeaderMode").hidden = true;
    document.getElementById("OrderHistory").hidden = true;
    document.getElementById("HeaderCartMobile").hidden = true;
    document.getElementById("HeaderUserMobile").hidden = true;
    document.getElementById("HeaderModeMobile").hidden = true;

    document.getElementById("HeaderLogin").hidden = false;
    document.getElementById("HeaderLoginMobile").hidden = false;
    document.getElementById("HeaderLoginMobile001").hidden = false;
    var userName = window.localStorage.getItem('UserName');
    if (userName) {
        if (userName.length > 0) {
            var firstName = window.localStorage.getItem('FirstName');
            if (firstName) {
                if (firstName.length > 0) {
                    if (firstName.toUpperCase() != 'UNDEFINED') {
                        var cart = window.localStorage.getItem('Cart');
                        document.getElementById("HeaderCartMobile").hidden = false;
                        document.getElementById("HeaderUserMobile").hidden = false;
                        document.getElementById("HeaderCart").hidden = false;
                        document.getElementById("HeaderUser").hidden = false;
                        document.getElementById("HeaderLogin").hidden = true;
                        document.getElementById("HeaderLoginMobile").hidden = true;
                        document.getElementById("HeaderLoginMobile001").hidden = true;
                        document.getElementById("FirstName").innerHTML = firstName;
                        document.getElementById("Cart").innerHTML = cart;
                        document.getElementById("FirstNameMobile").innerHTML = firstName;
                        document.getElementById("CartMobile").innerHTML = cart;
                        var userRole = window.localStorage.getItem('UserRole');
                        if (userRole) {
                            if ((userRole == 'Dealer') || (userRole == 'Designer')) {
                                document.getElementById("HeaderMode").hidden = false;
                                document.getElementById("HeaderModeMobile").hidden = false;
                                document.getElementById("OrderHistory").hidden = false;

                                var userRetail = window.localStorage.getItem('UserRetail');
                                document.getElementById("HeaderRetailRetail").hidden = true;
                                document.getElementById("HeaderRetailMobileRetail").hidden = true;
                                document.getElementById("HeaderRetailPurchase").hidden = true;
                                document.getElementById("HeaderRetailMobilePurchase").hidden = true;
                                document.getElementById("HeaderRetailCheckbox").checked = false;
                                document.getElementById("HeaderRetailMobileCheckbox").checked = false;
                                if (userRetail == "1") {
                                    document.getElementById("HeaderRetailCheckbox").checked = true;
                                    document.getElementById("HeaderRetailMobileCheckbox").checked = true;
                                    document.getElementById("HeaderRetailPurchase").hidden = false;
                                    document.getElementById("HeaderRetailMobilePurchase").hidden = false;
                                }
                                else {
                                    document.getElementById("HeaderRetailCheckbox").checked = false;
                                    document.getElementById("HeaderRetailMobileCheckbox").checked = false;
                                    document.getElementById("HeaderRetailRetail").hidden = false;
                                    document.getElementById("HeaderRetailMobileRetail").hidden = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
function onSearchOpen() {
    var width = window.innerWidth / 2;
    var right = window.innerWidth - window.localStorage.getItem('HeaderSearchTextRight') - 46;
    document.getElementById("MenuBrandParent").hidden = true;
    document.getElementById("MenuProductParent").hidden = true;
    document.getElementById("MenuCustomParent").hidden = true;
    document.getElementById("MenuLocationsParent").hidden = true;
    document.getElementById("MenuBlogParent").hidden = true;
    document.getElementById("MenuAboutUsParent").hidden = true;
    document.getElementById("HeaderSearchText").hidden = true;
    document.getElementById("HeaderSearch").hidden = false;
    document.getElementById("HeaderSearchInput").focus();
    document.getElementById("HeaderSearchInput").style.width = width + "px";
    document.getElementById("HeaderSearchIcon").style.position = "fixed";
    document.getElementById("HeaderSearchIcon").style.top = window.localStorage.getItem('HeaderSearchTextTop') + "px";
    document.getElementById("HeaderSearchIcon").style.right = right + "px";
    var value = document.getElementById('HeaderSearchInput').value;
    if (value) {
        window.location.href = 'http://web-test.theodorealexander.com/special/search.html?searchString=' + value;
    }
}
function onSearchClose() {
    document.getElementById("MenuBrandParent").hidden = false;
    document.getElementById("MenuProductParent").hidden = false;
    document.getElementById("MenuCustomParent").hidden = false;
    document.getElementById("MenuLocationsParent").hidden = false;
    document.getElementById("MenuBlogParent").hidden = false;
    document.getElementById("MenuAboutUsParent").hidden = false;
    document.getElementById("HeaderSearchText").hidden = false;
    document.getElementById("HeaderSearch").hidden = true;
}
function onHeaderSearchInputEnter(ele) {
    if (event.key === 'Enter') {
        if (ele.value) {
            window.location.href = 'http://web-test.theodorealexander.com/special/search.html?searchString=' + ele.value;
        }
    }
}
function onHeaderSearchInputMobileEnter(ele) {
    if (event.key === 'Enter') {
        if (ele.value) {
            window.location.href = 'http://web-test.theodorealexander.com/special/search.html?searchString=' + ele.value;
        }
    }
}
function onHeaderSearchInputMobile() {
    var value = document.getElementById('HeaderSearchInputMobile').value;
    if (value) {
        window.location.href = 'http://web-test.theodorealexander.com/special/search.html?searchString=' + value;
    }
}
function onBodySearchStringEnter(ele) {
    if (event.key === 'Enter') {
        if (ele.value) {
            window.location.href = 'http://web-test.theodorealexander.com/special/search.html?searchString=' + ele.value;
        }
    }
}
function onBodySearchStringClick() {
    var value = document.getElementById('BodySearchString').value;
    if (value) {
        window.location.href = 'http://web-test.theodorealexander.com/special/search.html?searchString=' + value;
    }
}
function onBodySearchStringMobileEnter(ele) {
    if (event.key === 'Enter') {
        if (ele.value) {
            window.location.href = 'http://web-test.theodorealexander.com/special/search.html?searchString=' + ele.value;
        }
    }
}
function onBodySearchStringMobileClick() {
    var value = document.getElementById('BodySearchStringMobile').value;
    if (value) {
        window.location.href = 'http://web-test.theodorealexander.com/special/search.html?searchString=' + value;
    }
}
function onHeaderSearchMobileOpen() {
    var searchMobileHidden = document.getElementById("SearchMobile").hidden;
    if (searchMobileHidden) {
        var width = window.innerWidth;
        var paddingTop = window.innerHeight / 2 - 50;
        var paddingBottom = window.innerHeight / 2;
        document.getElementById("SearchMobile").hidden = false;
        document.getElementById("SearchMobile").style.width = width + "px";
        document.getElementById("SearchMobile").style.paddingTop = paddingTop + "px";
        document.getElementById("SearchMobile").style.paddingBottom = paddingBottom + "px";

        document.getElementById('HeaderSearchMobile').className = '';
        document.getElementById("HeaderSearchMobile").classList.add("icon-close");

        document.getElementById("MenuMobile").hidden = true;
        document.getElementById('HeaderMenuMobile').className = '';
        document.getElementById("HeaderMenuMobile").classList.add("icon-menu-3");
    }
    else {
        document.getElementById("SearchMobile").hidden = true;
        document.getElementById('HeaderSearchMobile').className = '';
        document.getElementById("HeaderSearchMobile").classList.add("icon-search");
    }
}
function onHeaderMenuMobileOpen() {
    var menuMobileHidden = document.getElementById("MenuMobile").hidden;
    if (menuMobileHidden) {
        var width = window.innerWidth;
        var height = window.innerHeight - 70;
        document.getElementById("MenuMobile").hidden = false;
        document.getElementById("MenuMobile").style.width = width + "px";
        document.getElementById("MenuMobile").style.height = height + "px";

        document.getElementById('HeaderMenuMobile').className = '';
        document.getElementById("HeaderMenuMobile").classList.add("icon-close");

        document.getElementById("SearchMobile").hidden = true;
        document.getElementById('HeaderSearchMobile').className = '';
        document.getElementById("HeaderSearchMobile").classList.add("icon-search");
    }
    else {
        document.getElementById("MenuMobile").hidden = true;
        document.getElementById('HeaderMenuMobile').className = '';
        document.getElementById("HeaderMenuMobile").classList.add("icon-menu-3");
    }
}
function onMenuAboutUsMobileOpen() {
    document.getElementById("MenuBrandsMobile").hidden = true;
    document.getElementById("MenuProductsMobile").hidden = true;
    document.getElementById("MenuCustomMobile").hidden = true;

    document.getElementById('MenuBrandsMobileIcon').className = '';
    document.getElementById("MenuBrandsMobileIcon").classList.add("icon-arrow_menu_mobile");
    document.getElementById('MenuProductsMobileIcon').className = '';
    document.getElementById("MenuProductsMobileIcon").classList.add("icon-arrow_menu_mobile");
    document.getElementById('MenuCustomMobileIcon').className = '';
    document.getElementById("MenuCustomMobileIcon").classList.add("icon-arrow_menu_mobile");

    var menuMobileHidden = document.getElementById("MenuAboutUsMobile").hidden;
    if (menuMobileHidden) {
        document.getElementById("MenuAboutUsMobile").hidden = false;
        document.getElementById('MenuAboutUsMobileIcon').className = '';
        document.getElementById("MenuAboutUsMobileIcon").classList.add("icon-arrow_dropdown");
    }
    else {
        document.getElementById("MenuAboutUsMobile").hidden = true;
        document.getElementById('MenuAboutUsMobileIcon').className = '';
        document.getElementById("MenuAboutUsMobileIcon").classList.add("icon-arrow_menu_mobile");
    }
}
function onMenuCustomMobileOpen() {
    document.getElementById("MenuBrandsMobile").hidden = true;
    document.getElementById("MenuProductsMobile").hidden = true;
    document.getElementById("MenuAboutUsMobile").hidden = true;

    document.getElementById('MenuBrandsMobileIcon').className = '';
    document.getElementById("MenuBrandsMobileIcon").classList.add("icon-arrow_menu_mobile");
    document.getElementById('MenuProductsMobileIcon').className = '';
    document.getElementById("MenuProductsMobileIcon").classList.add("icon-arrow_menu_mobile");
    document.getElementById('MenuAboutUsMobileIcon').className = '';
    document.getElementById("MenuAboutUsMobileIcon").classList.add("icon-arrow_menu_mobile");

    var menuCustomHidden = document.getElementById("MenuCustomMobile").hidden;
    if (menuCustomHidden) {
        document.getElementById("MenuCustomMobile").hidden = false;
        document.getElementById('MenuCustomMobileIcon').className = '';
        document.getElementById("MenuCustomMobileIcon").classList.add("icon-arrow_dropdown");
    }
    else {
        document.getElementById("MenuCustomMobile").hidden = true;
        document.getElementById('MenuCustomMobileIcon').className = '';
        document.getElementById("MenuCustomMobileIcon").classList.add("icon-arrow_menu_mobile");
    }
}
function onMenuProductsMobileOpen() {
    document.getElementById("MenuBrandsMobile").hidden = true;
    document.getElementById("MenuCustomMobile").hidden = true;
    document.getElementById("MenuAboutUsMobile").hidden = true;

    document.getElementById('MenuBrandsMobileIcon').className = '';
    document.getElementById("MenuBrandsMobileIcon").classList.add("icon-arrow_menu_mobile");
    document.getElementById('MenuCustomMobileIcon').className = '';
    document.getElementById("MenuCustomMobileIcon").classList.add("icon-arrow_menu_mobile");
    document.getElementById('MenuAboutUsMobileIcon').className = '';
    document.getElementById("MenuAboutUsMobileIcon").classList.add("icon-arrow_menu_mobile");


    var menuProductsHidden = document.getElementById("MenuProductsMobile").hidden;
    if (menuProductsHidden) {
        document.getElementById("MenuProductsMobile").hidden = false;
        document.getElementById('MenuProductsMobileIcon').className = '';
        document.getElementById("MenuProductsMobileIcon").classList.add("icon-arrow_dropdown");
    }
    else {
        document.getElementById("MenuProductsMobile").hidden = true;
        document.getElementById('MenuProductsMobileIcon').className = '';
        document.getElementById("MenuProductsMobileIcon").classList.add("icon-arrow_menu_mobile");
    }
}
function onMenuBrandsMobileOpen() {
    document.getElementById("MenuProductsMobile").hidden = true;
    document.getElementById("MenuCustomMobile").hidden = true;
    document.getElementById("MenuAboutUsMobile").hidden = true;

    document.getElementById('MenuProductsMobileIcon').className = '';
    document.getElementById("MenuProductsMobileIcon").classList.add("icon-arrow_menu_mobile");
    document.getElementById('MenuCustomMobileIcon').className = '';
    document.getElementById("MenuCustomMobileIcon").classList.add("icon-arrow_menu_mobile");
    document.getElementById('MenuAboutUsMobileIcon').className = '';
    document.getElementById("MenuAboutUsMobileIcon").classList.add("icon-arrow_menu_mobile");

    var menuBrandsHidden = document.getElementById("MenuBrandsMobile").hidden;
    if (menuBrandsHidden) {
        document.getElementById("MenuBrandsMobile").hidden = false;
        document.getElementById('MenuBrandsMobileIcon').className = '';
        document.getElementById("MenuBrandsMobileIcon").classList.add("icon-arrow_dropdown");
    }
    else {
        document.getElementById("MenuBrandsMobile").hidden = true;
        document.getElementById('MenuBrandsMobileIcon').className = '';
        document.getElementById("MenuBrandsMobileIcon").classList.add("icon-arrow_menu_mobile");
    }
}
function onMenuLIVINGROOMMobileOpen() {
    document.getElementById("MenuDININGROOMMobile").hidden = true;
    document.getElementById("MenuBEDROOMMobile").hidden = true;
    document.getElementById("MenuOFFICEMobile").hidden = true;
    document.getElementById("MenuLIGHTINGMobile").hidden = true;
    document.getElementById("MenuDECORMobile").hidden = true;

    document.getElementById('MenuDININGROOMMobileIcon').className = '';
    document.getElementById("MenuDININGROOMMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuBEDROOMMobileIcon').className = '';
    document.getElementById("MenuBEDROOMMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuOFFICEMobileIcon').className = '';
    document.getElementById("MenuOFFICEMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuLIGHTINGMobileIcon').className = '';
    document.getElementById("MenuLIGHTINGMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuDECORMobileIcon').className = '';
    document.getElementById("MenuDECORMobileIcon").classList.add("icon-plus");

    var menuLivingRoomMobileHidden = document.getElementById("MenuLIVINGROOMMobile").hidden;
    if (menuLivingRoomMobileHidden) {
        document.getElementById("MenuLIVINGROOMMobile").hidden = false;
        document.getElementById('MenuLIVINGROOMMobileIcon').className = '';
        document.getElementById("MenuLIVINGROOMMobileIcon").classList.add("icon-minus");
    }
    else {
        document.getElementById("MenuLIVINGROOMMobile").hidden = true;
        document.getElementById('MenuLIVINGROOMMobileIcon').className = '';
        document.getElementById("MenuLIVINGROOMMobileIcon").classList.add("icon-plus");
    }
}
function onMenuDININGROOMMobileOpen() {
    document.getElementById("MenuLIVINGROOMMobile").hidden = true;
    document.getElementById("MenuBEDROOMMobile").hidden = true;
    document.getElementById("MenuOFFICEMobile").hidden = true;
    document.getElementById("MenuLIGHTINGMobile").hidden = true;
    document.getElementById("MenuDECORMobile").hidden = true;

    document.getElementById('MenuLIVINGROOMMobileIcon').className = '';
    document.getElementById("MenuLIVINGROOMMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuBEDROOMMobileIcon').className = '';
    document.getElementById("MenuBEDROOMMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuOFFICEMobileIcon').className = '';
    document.getElementById("MenuOFFICEMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuLIGHTINGMobileIcon').className = '';
    document.getElementById("MenuLIGHTINGMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuDECORMobileIcon').className = '';
    document.getElementById("MenuDECORMobileIcon").classList.add("icon-plus");

    var menuDININGROOMMobileIconHidden = document.getElementById("MenuDININGROOMMobile").hidden;
    if (menuDININGROOMMobileIconHidden) {
        document.getElementById("MenuDININGROOMMobile").hidden = false;
        document.getElementById('MenuDININGROOMMobileIcon').className = '';
        document.getElementById("MenuDININGROOMMobileIcon").classList.add("icon-minus");
    }
    else {
        document.getElementById("MenuDININGROOMMobile").hidden = true;
        document.getElementById('MenuDININGROOMMobileIcon').className = '';
        document.getElementById("MenuDININGROOMMobileIcon").classList.add("icon-plus");
    }
}
function onMenuBEDROOMMobileOpen() {
    document.getElementById("MenuLIVINGROOMMobile").hidden = true;
    document.getElementById("MenuDININGROOMMobile").hidden = true;
    document.getElementById("MenuOFFICEMobile").hidden = true;
    document.getElementById("MenuLIGHTINGMobile").hidden = true;
    document.getElementById("MenuDECORMobile").hidden = true;

    document.getElementById('MenuLIVINGROOMMobileIcon').className = '';
    document.getElementById("MenuLIVINGROOMMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuDININGROOMMobileIcon').className = '';
    document.getElementById("MenuDININGROOMMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuOFFICEMobileIcon').className = '';
    document.getElementById("MenuOFFICEMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuLIGHTINGMobileIcon').className = '';
    document.getElementById("MenuLIGHTINGMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuDECORMobileIcon').className = '';
    document.getElementById("MenuDECORMobileIcon").classList.add("icon-plus");

    var menuBEDROOMMobileHidden = document.getElementById("MenuBEDROOMMobile").hidden;
    if (menuBEDROOMMobileHidden) {
        document.getElementById("MenuBEDROOMMobile").hidden = false;
        document.getElementById('MenuBEDROOMMobileIcon').className = '';
        document.getElementById("MenuBEDROOMMobileIcon").classList.add("icon-minus");
    }
    else {
        document.getElementById("MenuBEDROOMMobile").hidden = true;
        document.getElementById('MenuBEDROOMMobileIcon').className = '';
        document.getElementById("MenuBEDROOMMobileIcon").classList.add("icon-plus");
    }
}
function onMenuOFFICEMobileOpen() {
    document.getElementById("MenuLIVINGROOMMobile").hidden = true;
    document.getElementById("MenuDININGROOMMobile").hidden = true;
    document.getElementById("MenuBEDROOMMobile").hidden = true;
    document.getElementById("MenuLIGHTINGMobile").hidden = true;
    document.getElementById("MenuDECORMobile").hidden = true;

    document.getElementById('MenuLIVINGROOMMobileIcon').className = '';
    document.getElementById("MenuLIVINGROOMMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuDININGROOMMobileIcon').className = '';
    document.getElementById("MenuDININGROOMMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuBEDROOMMobileIcon').className = '';
    document.getElementById("MenuBEDROOMMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuLIGHTINGMobileIcon').className = '';
    document.getElementById("MenuLIGHTINGMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuDECORMobileIcon').className = '';
    document.getElementById("MenuDECORMobileIcon").classList.add("icon-plus");

    var menuOFFICEMobileHidden = document.getElementById("MenuOFFICEMobile").hidden;
    if (menuOFFICEMobileHidden) {
        document.getElementById("MenuOFFICEMobile").hidden = false;
        document.getElementById('MenuOFFICEMobileIcon').className = '';
        document.getElementById("MenuOFFICEMobileIcon").classList.add("icon-minus");
    }
    else {
        document.getElementById("MenuOFFICEMobile").hidden = true;
        document.getElementById('MenuOFFICEMobileIcon').className = '';
        document.getElementById("MenuOFFICEMobileIcon").classList.add("icon-plus");
    }
}
function onMenuLIGHTINGMobileOpen() {
    document.getElementById("MenuLIVINGROOMMobile").hidden = true;
    document.getElementById("MenuDININGROOMMobile").hidden = true;
    document.getElementById("MenuBEDROOMMobile").hidden = true;
    document.getElementById("MenuOFFICEMobile").hidden = true;
    document.getElementById("MenuDECORMobile").hidden = true;

    document.getElementById('MenuLIVINGROOMMobileIcon').className = '';
    document.getElementById("MenuLIVINGROOMMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuDININGROOMMobileIcon').className = '';
    document.getElementById("MenuDININGROOMMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuBEDROOMMobileIcon').className = '';
    document.getElementById("MenuBEDROOMMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuOFFICEMobileIcon').className = '';
    document.getElementById("MenuOFFICEMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuDECORMobileIcon').className = '';
    document.getElementById("MenuDECORMobileIcon").classList.add("icon-plus");

    var MenuLIGHTINGMobileHidden = document.getElementById("MenuLIGHTINGMobile").hidden;
    if (MenuLIGHTINGMobileHidden) {
        document.getElementById("MenuLIGHTINGMobile").hidden = false;
        document.getElementById('MenuLIGHTINGMobileIcon').className = '';
        document.getElementById("MenuLIGHTINGMobileIcon").classList.add("icon-minus");
    }
    else {
        document.getElementById("MenuLIGHTINGMobile").hidden = true;
        document.getElementById('MenuLIGHTINGMobileIcon').className = '';
        document.getElementById("MenuLIGHTINGMobileIcon").classList.add("icon-plus");
    }
}
function onMenuDECORMobileOpen() {
    document.getElementById("MenuLIVINGROOMMobile").hidden = true;
    document.getElementById("MenuDININGROOMMobile").hidden = true;
    document.getElementById("MenuBEDROOMMobile").hidden = true;
    document.getElementById("MenuOFFICEMobile").hidden = true;
    document.getElementById("MenuLIGHTINGMobile").hidden = true;

    document.getElementById('MenuLIVINGROOMMobileIcon').className = '';
    document.getElementById("MenuLIVINGROOMMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuDININGROOMMobileIcon').className = '';
    document.getElementById("MenuDININGROOMMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuBEDROOMMobileIcon').className = '';
    document.getElementById("MenuBEDROOMMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuOFFICEMobileIcon').className = '';
    document.getElementById("MenuOFFICEMobileIcon").classList.add("icon-plus");
    document.getElementById('MenuLIGHTINGMobileIcon').className = '';
    document.getElementById("MenuLIGHTINGMobileIcon").classList.add("icon-plus");

    var menuDECORMobileHidden = document.getElementById("MenuDECORMobile").hidden;
    if (menuDECORMobileHidden) {
        document.getElementById("MenuDECORMobile").hidden = false;
        document.getElementById('MenuDECORMobileIcon').className = '';
        document.getElementById("MenuDECORMobileIcon").classList.add("icon-minus");
    }
    else {
        document.getElementById("MenuDECORMobile").hidden = true;
        document.getElementById('MenuDECORMobileIcon').className = '';
        document.getElementById("MenuDECORMobileIcon").classList.add("icon-plus");
    }
}
function onMenuTheodoreAlexanderMobileOpen() {

    document.getElementById("MenuSALONEMobileSub").hidden = true;
    document.getElementById("MenuTAStudioMobileSub").hidden = true;
    document.getElementById("MenuRalphLaurenMobileSub").hidden = true;

    document.getElementById('MenuSALONEMobile').className = '';
    document.getElementById("MenuSALONEMobile").classList.add("block_menu_item_head");
    document.getElementById('MenuTAStudioMobile').className = '';
    document.getElementById("MenuTAStudioMobile").classList.add("block_menu_item_head");
    document.getElementById('MenuRalphLaurenMobile').className = '';
    document.getElementById("MenuRalphLaurenMobile").classList.add("block_menu_item_head");

    var menuTheodoreAlexanderMobileSubHidden = document.getElementById("MenuTheodoreAlexanderMobileSub").hidden;
    if (menuTheodoreAlexanderMobileSubHidden) {
        document.getElementById("MenuTheodoreAlexanderMobileSub").hidden = false;
        document.getElementById('MenuTheodoreAlexanderMobile').className = '';
    }
    else {
        document.getElementById("MenuTheodoreAlexanderMobileSub").hidden = true;
        document.getElementById('MenuTheodoreAlexanderMobile').className = '';
        document.getElementById("MenuTheodoreAlexanderMobile").classList.add("block_menu_item_head");
    }
}
function onMenuSALONEMobileOpen() {

    document.getElementById("MenuTheodoreAlexanderMobileSub").hidden = true;
    document.getElementById("MenuTAStudioMobileSub").hidden = true;
    document.getElementById("MenuRalphLaurenMobileSub").hidden = true;

    document.getElementById('MenuTheodoreAlexanderMobile').className = '';
    document.getElementById("MenuTheodoreAlexanderMobile").classList.add("block_menu_item_head");
    document.getElementById('MenuTAStudioMobile').className = '';
    document.getElementById("MenuTAStudioMobile").classList.add("block_menu_item_head");
    document.getElementById('MenuRalphLaurenMobile').className = '';
    document.getElementById("MenuRalphLaurenMobile").classList.add("block_menu_item_head");

    var menuSALONEMobileSubHidden = document.getElementById("MenuSALONEMobileSub").hidden;
    if (menuSALONEMobileSubHidden) {
        document.getElementById("MenuSALONEMobileSub").hidden = false;
        document.getElementById('MenuSALONEMobile').className = '';
    }
    else {
        document.getElementById("MenuSALONEMobileSub").hidden = true;
        document.getElementById('MenuSALONEMobile').className = '';
        document.getElementById("MenuSALONEMobile").classList.add("block_menu_item_head");
    }
}
function onMenuTAStudioMobileOpen() {

    document.getElementById("MenuTheodoreAlexanderMobileSub").hidden = true;
    document.getElementById("MenuSALONEMobileSub").hidden = true;
    document.getElementById("MenuRalphLaurenMobileSub").hidden = true;

    document.getElementById('MenuTheodoreAlexanderMobile').className = '';
    document.getElementById("MenuTheodoreAlexanderMobile").classList.add("block_menu_item_head");
    document.getElementById('MenuSALONEMobile').className = '';
    document.getElementById("MenuSALONEMobile").classList.add("block_menu_item_head");
    document.getElementById('MenuRalphLaurenMobile').className = '';
    document.getElementById("MenuRalphLaurenMobile").classList.add("block_menu_item_head");

    var menuTAStudioMobileHidden = document.getElementById("MenuTAStudioMobileSub").hidden;
    if (menuTAStudioMobileHidden) {
        document.getElementById("MenuTAStudioMobileSub").hidden = false;
        document.getElementById('MenuTAStudioMobile').className = '';
    }
    else {
        document.getElementById("MenuTAStudioMobileSub").hidden = true;
        document.getElementById('MenuTAStudioMobile').className = '';
        document.getElementById("MenuTAStudioMobile").classList.add("block_menu_item_head");
    }
}
function onMenuRalphLaurenMobileOpen() {
    document.getElementById("MenuTheodoreAlexanderMobileSub").hidden = true;
    document.getElementById("MenuSALONEMobileSub").hidden = true;
    document.getElementById("MenuTAStudioMobileSub").hidden = true;

    document.getElementById('MenuTheodoreAlexanderMobile').className = '';
    document.getElementById("MenuTheodoreAlexanderMobile").classList.add("block_menu_item_head");
    document.getElementById('MenuSALONEMobile').className = '';
    document.getElementById("MenuSALONEMobile").classList.add("block_menu_item_head");
    document.getElementById('MenuTAStudioMobile').className = '';
    document.getElementById("MenuTAStudioMobile").classList.add("block_menu_item_head");

    var menuRalphLaurenMobileSubHidden = document.getElementById("MenuRalphLaurenMobileSub").hidden;
    if (menuRalphLaurenMobileSubHidden) {
        document.getElementById("MenuRalphLaurenMobileSub").hidden = false;
        document.getElementById('MenuRalphLaurenMobile').className = '';
    }
    else {
        document.getElementById("MenuRalphLaurenMobileSub").hidden = true;
        document.getElementById('MenuRalphLaurenMobile').className = '';
        document.getElementById("MenuRalphLaurenMobile").classList.add("block_menu_item_head");
    }
}
function onMenuCollectionsMobileOpen() {
    document.getElementById("MenuDesignPartnersMobile").hidden = true;
    document.getElementById('MenuDesignPartnersMobileIcon').className = '';
    document.getElementById("MenuDesignPartnersMobileIcon").classList.add("icon-plus");

    var menuCollectionsMobileHidden = document.getElementById("MenuCollectionsMobile").hidden;
    if (menuCollectionsMobileHidden) {
        document.getElementById("MenuCollectionsMobile").hidden = false;
        document.getElementById('MenuCollectionsMobileIcon').className = '';
        document.getElementById("MenuCollectionsMobileIcon").classList.add("icon-minus");
    }
    else {
        document.getElementById("MenuCollectionsMobile").hidden = true;
        document.getElementById('MenuCollectionsMobileIcon').className = '';
        document.getElementById("MenuCollectionsMobileIcon").classList.add("icon-plus");
    }
}
function onMenuDesignPartnersMobileOpen() {
    document.getElementById("MenuCollectionsMobile").hidden = true;
    document.getElementById('MenuCollectionsMobileIcon').className = '';
    document.getElementById("MenuCollectionsMobileIcon").classList.add("icon-plus");

    var menuDesignPartnersMobileHidden = document.getElementById("MenuDesignPartnersMobile").hidden;
    if (menuDesignPartnersMobileHidden) {
        document.getElementById("MenuDesignPartnersMobile").hidden = false;
        document.getElementById('MenuDesignPartnersMobileIcon').className = '';
        document.getElementById("MenuDesignPartnersMobileIcon").classList.add("icon-minus");
    }
    else {
        document.getElementById("MenuDesignPartnersMobile").hidden = true;
        document.getElementById('MenuDesignPartnersMobileIcon').className = '';
        document.getElementById("MenuDesignPartnersMobileIcon").classList.add("icon-plus");
    }
}
function onHeaderRetailChange(checkbox) {
    if (checkbox.checked) {
        document.getElementById("HeaderRetailRetail").hidden = true;
        document.getElementById("HeaderRetailMobileRetail").hidden = true;
        document.getElementById("HeaderRetailPurchase").hidden = false;
        document.getElementById("HeaderRetailMobilePurchase").hidden = false;
        localStorage.setItem('UserRetail', '1');
    }
    else {
        document.getElementById("HeaderRetailRetail").hidden = false;
        document.getElementById("HeaderRetailMobileRetail").hidden = false;
        document.getElementById("HeaderRetailPurchase").hidden = true;
        document.getElementById("HeaderRetailMobilePurchase").hidden = true;
        localStorage.setItem('UserRetail', '0');
    }
}
function onHeaderRetailMobileChange(checkbox) {
    if (checkbox.checked) {
        document.getElementById("HeaderRetailRetail").hidden = true;
        document.getElementById("HeaderRetailMobileRetail").hidden = true;
        document.getElementById("HeaderRetailPurchase").hidden = false;
        document.getElementById("HeaderRetailMobilePurchase").hidden = false;
        localStorage.setItem('UserRetail', '1');
    }
    else {
        document.getElementById("HeaderRetailRetail").hidden = false;
        document.getElementById("HeaderRetailMobileRetail").hidden = false;
        document.getElementById("HeaderRetailPurchase").hidden = true;
        document.getElementById("HeaderRetailMobilePurchase").hidden = true;
        localStorage.setItem('UserRetail', '0');
    }
}
function onCollectionMenuItems() {
    var url = "http://api-test.theodorealexander.com/api/Collection/GetByIsActiveToList";
    $.ajax({
        type: "GET",
        url: url,
        data: {
            "isActive": true
        },
        headers: {
            "Ip_Address": '172.18.3.74',
            "API_KEY": 'X-some-key',
            'Authorization': ''
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            window.localStorage.setItem("CollectionList", JSON.stringify(data.Data));
        },
        error: function (err) {
        }
    });
}
function onTypeMenuItems() {
    var url = "http://api-test.theodorealexander.com/api/Type/GetByIsActiveToList";
    $.ajax({
        type: "GET",
        url: url,
        data: {
            "isActive": true
        },
        headers: {
            "Ip_Address": '172.18.3.74',
            "API_KEY": 'X-some-key',
            'Authorization': ''
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            window.localStorage.setItem("TypeList", JSON.stringify(data.Data));
        },
        error: function (err) {
        }
    });
}
function onLifeStyleMenuItems() {
    var url = "http://api-test.theodorealexander.com/api/LifeStyle/GetByIsActiveToList";
    $.ajax({
        type: "GET",
        url: url,
        data: {
            "isActive": true
        },
        headers: {
            "Ip_Address": '172.18.3.74',
            "API_KEY": 'X-some-key',
            'Authorization': ''
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            window.localStorage.setItem("LifeStyleList", JSON.stringify(data.Data));
        },
        error: function (err) {
        }
    });
}
function onStyleMenuItems() {
    var url = "http://api-test.theodorealexander.com/api/Style/GetByIsActiveToList";
    $.ajax({
        type: "GET",
        url: url,
        data: {
            "isActive": true
        },
        headers: {
            "Ip_Address": '172.18.3.74',
            "API_KEY": 'X-some-key',
            'Authorization': ''
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            window.localStorage.setItem("StyleList", JSON.stringify(data.Data));
        },
        error: function (err) {
        }
    });
}
function onShapeMenuItems() {
    var url = "http://api-test.theodorealexander.com/api/Shape/GetByIsActiveToList";
    $.ajax({
        type: "GET",
        url: url,
        data: {
            "isActive": true
        },
        headers: {
            "Ip_Address": '172.18.3.74',
            "API_KEY": 'X-some-key',
            'Authorization': ''
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            window.localStorage.setItem("ShapeList", JSON.stringify(data.Data));
        },
        error: function (err) {
        }
    });
}
function onRoomMenuItems() {
    var url = "http://api-test.theodorealexander.com/api/RoomAndUsage/GetByIsActiveToList";
    $.ajax({
        type: "GET",
        url: url,
        data: {
            "isActive": true
        },
        headers: {
            "Ip_Address": '172.18.3.74',
            "API_KEY": 'X-some-key',
            'Authorization': ''
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            window.localStorage.setItem("RoomList", JSON.stringify(data.Data));
        },
        error: function (err) {
        }
    });
}
function onBrandMenuItems() {
    var url = "http://api-test.theodorealexander.com/api/Brand/GetByIsActiveToList";
    $.ajax({
        type: "GET",
        url: url,
        data: {
            "isActive": true
        },
        headers: {
            "Ip_Address": '172.18.3.74',
            "API_KEY": 'X-some-key',
            'Authorization': ''
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            window.localStorage.setItem("BrandList", JSON.stringify(data.Data));
        },
        error: function (err) {
        }
    });
}
function onDesignerMenuItems() {
    var url = "http://api-test.theodorealexander.com/api/Designer/GetByIsActiveToList";
    $.ajax({
        type: "GET",
        url: url,
        data: {
            "isActive": true
        },
        headers: {
            "Ip_Address": '172.18.3.74',
            "API_KEY": 'X-some-key',
            'Authorization': ''
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            window.localStorage.setItem("DesignerList", JSON.stringify(data.Data));
        },
        error: function (err) {
        }
    });
}

function onClickMobileFilterIcon(isView) {
    document.getElementById("ProductListSearchMobile").hidden = isView;
    document.getElementById("ProductListCloseMobile").hidden = isView;
    if (isView == false) {
        document.getElementById("ProductListMenu").className = '';
        document.getElementById("ProductListMenu").className = 'productFilter_sidebar ta_no_scrollbar d-none d-xl-flex flex-column productFilter_sidebar_mobile-open';
    }
    else {
        document.getElementById("ProductListMenu").className = '';
        document.getElementById("ProductListMenu").className = 'productFilter_sidebar ta_no_scrollbar d-none d-xl-flex flex-column';
    }
}
function onSwitchViewMode(isView) {
    if (isView == false) {
        document.getElementById("ProductListGridHorizontal").className = '';
        document.getElementById("ProductListGridHorizontal").className = 'icon-grid_horizontal';
        document.getElementById("ProductListGridVertical").className = '';
        document.getElementById("ProductListGridVertical").className = 'icon-grid_vertical active';
        document.getElementById("ProductListProductsUS").className = '';
        document.getElementById("ProductListProductsUS").className = 'products';
        document.getElementById("ProductListProductsInternational").className = '';
        document.getElementById("ProductListProductsInternational").className = 'products';
        document.getElementById("ProductListProductsLoad").className = '';
        document.getElementById("ProductListProductsLoad").className = 'products';
    }
    else {
        document.getElementById("ProductListGridVertical").className = '';
        document.getElementById("ProductListGridVertical").className = 'icon-grid_vertical';
        document.getElementById("ProductListGridHorizontal").className = '';
        document.getElementById("ProductListGridHorizontal").className = 'icon-grid_horizontal active';
        document.getElementById("ProductListProductsUS").className = '';
        document.getElementById("ProductListProductsUS").className = 'products isGridMode';
        document.getElementById("ProductListProductsInternational").className = '';
        document.getElementById("ProductListProductsInternational").className = 'products isGridMode';
        document.getElementById("ProductListProductsLoad").className = '';
        document.getElementById("ProductListProductsLoad").className = 'products isGridMode';
    }
    var productListDescription = document.getElementsByClassName('productFilter_content_productList_row_product_caption_description');
    for (var i = 0; i < productListDescription.length; i++) {
        productListDescription[i].hidden = isView;
    }
    var productListThemestyle = document.getElementsByClassName('productFilter_content_productList_row_product_themestyle');
    for (var i = 0; i < productListThemestyle.length; i++) {
        productListThemestyle[i].hidden = isView;
    }
}
function onProductListIsStockedMobileChange() {
    var isStocked = document.getElementById("ProductListIsStockedMobileCheckbox").checked;
    window.localStorage.setItem('isStocked', isStocked);
    getByQueryString001();
}
function onProductListIsStockedChange() {
    var isStocked = document.getElementById("ProductListIsStockedCheckbox").checked;
    window.localStorage.setItem('isStocked', isStocked);
    getByQueryString001();
}
function onProductListSortByMobileChange() {
    var sortBy = document.getElementById("ProductListSortByMobile").value;
    onSortBy(sortBy);
}
function onProductListSortByChange() {
    var sortBy = document.getElementById("ProductListSortBy").value;
    onSortBy(sortBy);
}
function onEXTENDINGChangeUS() {
    window.localStorage.setItem('LastClick', window.localStorage.getItem('NowClick'));
    window.localStorage.setItem('NowClick', 'Extending');
    var extending = window.localStorage.getItem('extending');
    if (extending == "true") {
        extending = false;
        document.getElementById("EXTENDINGUS").hidden = true;
    }
    if (extending == "false") {
        extending = true;
        document.getElementById("EXTENDINGUS").hidden = false;
    }
    if (extending == null) {
        extending = true;
        document.getElementById("EXTENDINGUS").hidden = false;
    }
    window.localStorage.setItem('extending', extending);
    getByQueryString001();
}
function onEXTENDINGChangeInternational() {
    window.localStorage.setItem('LastClick', window.localStorage.getItem('NowClick'));
    window.localStorage.setItem('NowClick', 'Extending');
    var extending = window.localStorage.getItem('extending');
    if (extending == "true") {
        extending = false;
        document.getElementById("EXTENDINGInternational").hidden = true;
    }
    if (extending == "false") {
        extending = true;
        document.getElementById("EXTENDINGInternational").hidden = false;
    }
    if (extending == null) {
        extending = true;
        document.getElementById("EXTENDINGInternational").hidden = false;
    }
    window.localStorage.setItem('extending', extending);
    getByQueryString001();
}
function checkClearAll() {

    var room_IDList = window.localStorage.getItem('room_IDList');
    var brand_IDList = window.localStorage.getItem('brand_IDList');
    var type_IDList = window.localStorage.getItem('type_IDList');
    var shape_IDList = window.localStorage.getItem('shape_IDList');
    var style_IDList = window.localStorage.getItem('style_IDList');
    var lifeStyle_IDList = window.localStorage.getItem('lifeStyle_IDList');
    var collection_IDList = window.localStorage.getItem('collection_IDList');
    var designer_IDList = window.localStorage.getItem('designer_IDList');

    room_IDList = room_IDList.replaceAll(";", "");
    room_IDList = room_IDList.trim();

    brand_IDList = brand_IDList.replaceAll(";", "");
    brand_IDList = brand_IDList.trim();

    type_IDList = type_IDList.replaceAll(";", "");
    type_IDList = type_IDList.trim();

    shape_IDList = shape_IDList.replaceAll(";", "");
    shape_IDList = shape_IDList.trim();

    style_IDList = style_IDList.replaceAll(";", "");
    style_IDList = style_IDList.trim();

    lifeStyle_IDList = lifeStyle_IDList.replaceAll(";", "");
    lifeStyle_IDList = lifeStyle_IDList.trim();

    collection_IDList = collection_IDList.replaceAll(";", "");
    collection_IDList = collection_IDList.trim();

    designer_IDList = designer_IDList.replaceAll(";", "");
    designer_IDList = designer_IDList.trim();

    if ((room_IDList.length == 0)
        && (brand_IDList.length == 0)
        && (type_IDList.length == 0)
        && (shape_IDList.length == 0)
        && (style_IDList.length == 0)
        && (lifeStyle_IDList.length == 0)
        && (collection_IDList.length == 0)
        && (designer_IDList.length == 0)) {
        document.getElementById("ProductListTags").hidden = true;
    }
    else {
        document.getElementById("ProductListTags").hidden = false;
    }
}
function onClearAll() {
    window.localStorage.setItem('LastClick', window.localStorage.getItem('NowClick'));
    window.localStorage.setItem('NowClick', '');
    document.getElementById("ProductListTags").hidden = true;
    window.localStorage.setItem('room_IDList', ';');
    window.localStorage.setItem('brand_IDList', ';');
    window.localStorage.setItem('type_IDList', ';');
    window.localStorage.setItem('shape_IDList', ';');
    window.localStorage.setItem('style_IDList', ';');
    window.localStorage.setItem('lifeStyle_IDList', ';');
    window.localStorage.setItem('collection_IDList', ';');
    getCollectionMenuItemsSub();
    getTypeMenuItemsSub();
    getShapeMenuItemsSub();
    getStyleMenuItemsSub();
    getLifeStyleMenuItemsSub();
    getByQueryString001();
}
function onCollectionTagClose(index) {
    if (index != null) {
        var ID = "CollectionMenu" + index;
        document.getElementById(ID).hidden = true;
        var list = JSON.parse(window.localStorage.getItem("CollectionList"));
        onCollectionSelect(list[index].ID, list[index].URLCode, 0);
    }
}
function onLifeStyleTagClose(index) {
    if (index != null) {
        var ID = "LifeStyleMenu" + index;
        document.getElementById(ID).hidden = true;
        var list = JSON.parse(window.localStorage.getItem("LifeStyleList"));
        onLifeStyleSelect(list[index].ID, list[index].URLCode, 0);
    }
}
function onStyleTagClose(index) {
    if (index != null) {
        var ID = "StyleMenu" + index;
        document.getElementById(ID).hidden = true;
        var list = JSON.parse(window.localStorage.getItem("StyleList"));
        onStyleSelect(list[index].ID, list[index].URLCode, 0);
    }
}
function onShapeTagClose(index) {
    if (index != null) {
        var ID = "ShapeMenu" + index;
        document.getElementById(ID).hidden = true;
        var list = JSON.parse(window.localStorage.getItem("ShapeList"));
        onShapeSelect(list[index].ID, list[index].URLCode, 0);
    }
}
function onTypeTagClose(index) {
    if (index != null) {
        var ID = "TypeMenu" + index;
        document.getElementById(ID).hidden = true;
        var list = JSON.parse(window.localStorage.getItem("TypeList"));
        onTypeSelect(list[index].ID, list[index].URLCode, 0);
    }
}
function onRoomTagClose(index) {
    if (index != null) {
        var ID = "RoomMenu" + index;
        document.getElementById(ID).hidden = true;
        var list = JSON.parse(window.localStorage.getItem("RoomList"));
        onRoomSelect(list[index].ID, list[index].URLCode, 0);
    }
}
function onBrandTagClose(index) {
    if (index != null) {
        var ID = "BrandMenu" + index;
        document.getElementById(ID).hidden = true;
        var list = JSON.parse(window.localStorage.getItem("BrandList"));
        onBrandSelect(list[index].ID, list[index].URLCode, 0);
    }
}
function onDesignerTagClose(index) {
    if (index != null) {
        var ID = "DesignerMenu" + index;
        document.getElementById(ID).hidden = true;
        var list = JSON.parse(window.localStorage.getItem("DesignerList"));
        onDesignerSelect(list[index].ID, list[index].URLCode, 0);
    }
}
function onCollectionChangeUS() {
    var listSubHidden = document.getElementById("CollectionListSubUS").hidden;
    if (listSubHidden == true) {
        document.getElementById("CollectionListSubUS").hidden = false;
        document.getElementById("CollectionListIconMinusUS").hidden = false;
        document.getElementById("CollectionListIconPlusUS").hidden = true;
    }
    else {
        document.getElementById("CollectionListSubUS").hidden = true;
        document.getElementById("CollectionListIconMinusUS").hidden = true;
        document.getElementById("CollectionListIconPlusUS").hidden = false;
    }
}
function onLifeStyleChangeUS() {
    var listSubHidden = document.getElementById("LifeStyleListSubUS").hidden;
    if (listSubHidden == true) {
        document.getElementById("LifeStyleListSubUS").hidden = false;
        document.getElementById("LifeStyleListIconMinusUS").hidden = false;
        document.getElementById("LifeStyleListIconPlusUS").hidden = true;
    }
    else {
        document.getElementById("LifeStyleListSubUS").hidden = true;
        document.getElementById("LifeStyleListIconMinusUS").hidden = true;
        document.getElementById("LifeStyleListIconPlusUS").hidden = false;
    }
}
function onStyleChangeUS() {
    var listSubHidden = document.getElementById("StyleListSubUS").hidden;
    if (listSubHidden == true) {
        document.getElementById("StyleListSubUS").hidden = false;
        document.getElementById("StyleListIconMinusUS").hidden = false;
        document.getElementById("StyleListIconPlusUS").hidden = true;
    }
    else {
        document.getElementById("StyleListSubUS").hidden = true;
        document.getElementById("StyleListIconMinusUS").hidden = true;
        document.getElementById("StyleListIconPlusUS").hidden = false;
    }
}
function onShapeChangeUS() {
    var listSubHidden = document.getElementById("ShapeListSubUS").hidden;
    if (listSubHidden == true) {
        document.getElementById("ShapeListSubUS").hidden = false;
        document.getElementById("ShapeListIconMinusUS").hidden = false;
        document.getElementById("ShapeListIconPlusUS").hidden = true;
    }
    else {
        document.getElementById("ShapeListSubUS").hidden = true;
        document.getElementById("ShapeListIconMinusUS").hidden = true;
        document.getElementById("ShapeListIconPlusUS").hidden = false;
    }
}
function onRoomChangeUS() {
    var listSubHidden = document.getElementById("RoomListSubUS").hidden;
    if (listSubHidden == true) {
        document.getElementById("RoomListSubUS").hidden = false;
        document.getElementById("RoomListIconMinusUS").hidden = false;
        document.getElementById("RoomListIconPlusUS").hidden = true;
    }
    else {
        document.getElementById("RoomListSubUS").hidden = true;
        document.getElementById("RoomListIconMinusUS").hidden = true;
        document.getElementById("RoomListIconPlusUS").hidden = false;
    }
}

function onCollectionChangeInternational() {
    var listSubHidden = document.getElementById("CollectionListSubInternational").hidden;
    if (listSubHidden == true) {
        document.getElementById("CollectionListSubInternational").hidden = false;
        document.getElementById("CollectionListIconMinusInternational").hidden = false;
        document.getElementById("CollectionListIconPlusInternational").hidden = true;
    }
    else {
        document.getElementById("CollectionListSubInternational").hidden = true;
        document.getElementById("CollectionListIconMinusInternational").hidden = true;
        document.getElementById("CollectionListIconPlusInternational").hidden = false;
    }
}
function onLifeStyleChangeInternational() {
    var listSubHidden = document.getElementById("LifeStyleListSubInternational").hidden;
    if (listSubHidden == true) {
        document.getElementById("LifeStyleListSubInternational").hidden = false;
        document.getElementById("LifeStyleListIconMinusInternational").hidden = false;
        document.getElementById("LifeStyleListIconPlusInternational").hidden = true;
    }
    else {
        document.getElementById("LifeStyleListSubInternational").hidden = true;
        document.getElementById("LifeStyleListIconMinusInternational").hidden = true;
        document.getElementById("LifeStyleListIconPlusInternational").hidden = false;
    }
}
function onStyleChangeInternational() {
    var listSubHidden = document.getElementById("StyleListSubInternational").hidden;
    if (listSubHidden == true) {
        document.getElementById("StyleListSubInternational").hidden = false;
        document.getElementById("StyleListIconMinusInternational").hidden = false;
        document.getElementById("StyleListIconPlusInternational").hidden = true;
    }
    else {
        document.getElementById("StyleListSubInternational").hidden = true;
        document.getElementById("StyleListIconMinusInternational").hidden = true;
        document.getElementById("StyleListIconPlusInternational").hidden = false;
    }
}
function onShapeChangeInternational() {
    var listSubHidden = document.getElementById("ShapeListSubInternational").hidden;
    if (listSubHidden == true) {
        document.getElementById("ShapeListSubInternational").hidden = false;
        document.getElementById("ShapeListIconMinusInternational").hidden = false;
        document.getElementById("ShapeListIconPlusInternational").hidden = true;
    }
    else {
        document.getElementById("ShapeListSubInternational").hidden = true;
        document.getElementById("ShapeListIconMinusInternational").hidden = true;
        document.getElementById("ShapeListIconPlusInternational").hidden = false;
    }
}
function onRoomChangeInternational() {
    var listSubHidden = document.getElementById("RoomListSubInternational").hidden;
    if (listSubHidden == true) {
        document.getElementById("RoomListSubInternational").hidden = false;
        document.getElementById("RoomListIconMinusInternational").hidden = false;
        document.getElementById("RoomListIconPlusInternational").hidden = true;
    }
    else {
        document.getElementById("RoomListSubInternational").hidden = true;
        document.getElementById("RoomListIconMinusInternational").hidden = true;
        document.getElementById("RoomListIconPlusInternational").hidden = false;
    }
}
function onRoomSubChange(ID) {
    var IDUS = ID + "US";
    var IDInternational = ID + "International";
    var listSubHidden = document.getElementById(IDUS).hidden;
    if (listSubHidden == true) {
        document.getElementById(IDUS).hidden = false;
        document.getElementById(IDInternational).hidden = false;
        document.getElementById(ID + 'IconUS').className = '';
        document.getElementById(ID + 'IconUS').classList.add("icon-arrow_dropdown");
        document.getElementById(ID + 'IconInternational').className = '';
        document.getElementById(ID + 'IconInternational').classList.add("icon-arrow_dropdown");
    }
    else {
        document.getElementById(IDUS).hidden = true;
        document.getElementById(IDInternational).hidden = true;
        document.getElementById(ID + 'IconUS').className = '';
        document.getElementById(ID + 'IconUS').classList.add("ngb_accordion_header_expand-collapse-indicatior-arrow");
        document.getElementById(ID + 'IconInternational').className = '';
        document.getElementById(ID + 'IconInternational').classList.add("ngb_accordion_header_expand-collapse-indicatior-arrow");
    }
}
function onCollectionSelect(ID, URLCode, action) {
    if (action == 1) {
        window.localStorage.setItem('LastClick', window.localStorage.getItem('NowClick'));
        window.localStorage.setItem('NowClick', 'Collection');
    }
    if (action == 0) {

    }
    ID = ID.toUpperCase();
    var region = window.localStorage.getItem('Region');
    if (region) {
        if (region.length > 0) {
            if (region == 'TAUS') {
                ID = ID + "US";
            }
            else {
                ID = ID + "International";
            }
        }
    }
    if (ID) {
        if (document.getElementById(ID)) {
            var IDHidden = document.getElementById(ID).hidden;
            IDHidden = !IDHidden;
            document.getElementById(ID).hidden = IDHidden;
            var IDList = window.localStorage.getItem('collection_IDList');
            if (IDList == null) {
                IDList = "";
            }
            if (IDHidden == false) {
                IDList = IDList + ";" + URLCode;
            }
            else {
                IDList = IDList.replace(URLCode, "");
            }
            window.localStorage.setItem("collection_IDList", IDList);
            getCollectionMenuItemsSub();
            getByQueryString001();
        }
    }
}
function onLifeStyleSelect(ID, URLCode, action) {
    if (action == 1) {
        window.localStorage.setItem('LastClick', window.localStorage.getItem('NowClick'));
        window.localStorage.setItem('NowClick', 'LifeStyle');
    }
    if (action == 0) {
    }
    ID = ID.toUpperCase();
    var region = window.localStorage.getItem('Region');
    if (region) {
        if (region.length > 0) {
            if (region == 'TAUS') {
                ID = ID + "US";
            }
            else {
                ID = ID + "International";
            }
        }
    }

    if (ID) {
        if (document.getElementById(ID)) {
            var IDHidden = document.getElementById(ID).hidden;
            IDHidden = !IDHidden;
            document.getElementById(ID).hidden = IDHidden;
            var IDList = window.localStorage.getItem('lifeStyle_IDList');
            if (IDList == null) {
                IDList = "";
            }
            if (IDHidden == false) {
                IDList = IDList + ";" + URLCode;
            }
            else {
                IDList = IDList.replace(URLCode, "");
            }
            window.localStorage.setItem("lifeStyle_IDList", IDList);
            getLifeStyleMenuItemsSub();
            getByQueryString001();
        }
    }
}
function onStyleSelect(ID, URLCode, action) {
    if (action == 1) {
        window.localStorage.setItem('LastClick', window.localStorage.getItem('NowClick'));
        window.localStorage.setItem('NowClick', 'Style');
    }
    if (action == 0) {

    }
    ID = ID.toUpperCase();
    var region = window.localStorage.getItem('Region');
    if (region) {
        if (region.length > 0) {
            if (region == 'TAUS') {
                ID = ID + "US";
            }
            else {
                ID = ID + "International";
            }
        }
    }
    if (ID) {
        if (document.getElementById(ID)) {
            var IDHidden = document.getElementById(ID).hidden;
            IDHidden = !IDHidden;
            document.getElementById(ID).hidden = IDHidden;
            var IDList = window.localStorage.getItem('style_IDList');
            if (IDList == null) {
                IDList = "";
            }
            if (IDHidden == false) {
                IDList = IDList + ";" + URLCode;
            }
            else {
                IDList = IDList.replace(URLCode, "");
            }
            window.localStorage.setItem("style_IDList", IDList);
            getStyleMenuItemsSub();
            getByQueryString001();
        }
    }
}
function onShapeSelect(ID, URLCode, action) {
    if (action == 1) {
        window.localStorage.setItem('LastClick', window.localStorage.getItem('NowClick'));
        window.localStorage.setItem('NowClick', 'Shape');
    }
    if (action == 0) {

    }
    ID = ID.toUpperCase();
    var region = window.localStorage.getItem('Region');
    if (region) {
        if (region.length > 0) {
            if (region == 'TAUS') {
                ID = ID + "US";
            }
            else {
                ID = ID + "International";
            }
        }
    }

    if (ID) {
        if (document.getElementById(ID)) {
            var IDHidden = document.getElementById(ID).hidden;
            IDHidden = !IDHidden;
            document.getElementById(ID).hidden = IDHidden;
            var IDList = window.localStorage.getItem('shape_IDList');
            if (IDList == null) {
                IDList = "";
            }
            if (IDHidden == false) {
                IDList = IDList + ";" + URLCode;
            }
            else {
                IDList = IDList.replace(URLCode, "");
            }
            window.localStorage.setItem("shape_IDList", IDList);
            getShapeMenuItemsSub();
            getByQueryString001();
        }
    }


}
function onTypeSelect(ID, URLCode, action) {
    if (action == 1) {
        window.localStorage.setItem('LastClick', window.localStorage.getItem('NowClick'));
        window.localStorage.setItem('NowClick', 'Type');
    }
    if (action == 0) {

    }
    ID = ID.toUpperCase();
    var region = window.localStorage.getItem('Region');
    if (region) {
        if (region.length > 0) {
            if (region == 'TAUS') {
                ID = ID + "US";
            }
            else {
                ID = ID + "International";
            }
        }
    }

    if (ID) {
        if (document.getElementById(ID)) {
            var IDHidden = document.getElementById(ID).hidden;
            IDHidden = !IDHidden;
            document.getElementById(ID).hidden = IDHidden;
            var IDList = window.localStorage.getItem('type_IDList');
            if (IDList == null) {
                IDList = "";
            }
            if (IDHidden == false) {
                IDList = IDList + ";" + URLCode;
            }
            else {
                IDList = IDList.replace(URLCode, "");
            }
            window.localStorage.setItem("type_IDList", IDList);
            getTypeMenuItemsSub();
            getByQueryString001();
        }
    }
}
function onRoomSelect(ID, URLCode, action) {
    ID = ID.toUpperCase();
    var region = window.localStorage.getItem('Region');
    if (region) {
        if (region.length > 0) {
            if (region == 'TAUS') {
                ID = ID + "US";
            }
            else {
                ID = ID + "International";
            }
        }
    }

    if (ID) {
        if (document.getElementById(ID)) {
            var IDHidden = document.getElementById(ID).hidden;
            IDHidden = !IDHidden;
            document.getElementById(ID).hidden = IDHidden;
            var IDList = window.localStorage.getItem('room_IDList');
            if (IDList == null) {
                IDList = "";
            }
            if (IDHidden == false) {
                IDList = IDList + ";" + URLCode;
            }
            else {
                IDList = IDList.replace(URLCode, "");
            }
            window.localStorage.setItem("room_IDList", IDList);
            getRoomMenuItemsSub();
            getByQueryString001();
        }
    }



}
function onBrandSelect(ID, URLCode, action) {
    ID = ID.toUpperCase();
    var region = window.localStorage.getItem('Region');
    if (region) {
        if (region.length > 0) {
            if (region == 'TAUS') {
                ID = ID + "US";
            }
            else {
                ID = ID + "International";
            }
        }
    }

    if (ID) {
        if (document.getElementById(ID)) {
            var IDHidden = document.getElementById(ID).hidden;
            IDHidden = !IDHidden;
            document.getElementById(ID).hidden = IDHidden;
            var IDList = window.localStorage.getItem('brand_IDList');
            if (IDList == null) {
                IDList = "";
            }
            if (IDHidden == false) {
                IDList = IDList + ";" + URLCode;
            }
            else {
                IDList = IDList.replace(URLCode, "");
            }
            window.localStorage.setItem("brand_IDList", IDList);
            getBrandMenuItemsSub();
            getByQueryString001();
        }
    }

}
function onDesignerSelect(ID, URLCode, action) {
    var IDList = window.localStorage.getItem('designer_IDList');
    if (IDList == null) {
        IDList = "";
    }
    IDList = IDList.replace(URLCode, "");
    window.localStorage.setItem("designer_IDList", IDList);
    getDesignerMenuItemsSub();
    getByQueryString001();
}

function getCollectionMenuItemsSub() {
    document.getElementById("ProductListLoader").hidden = false;

    document.getElementById("CollectionListSubUS").hidden = true;
    document.getElementById("CollectionListIconMinusUS").hidden = true;
    document.getElementById("CollectionListIconPlusUS").hidden = false;

    document.getElementById("CollectionListSubInternational").hidden = true;
    document.getElementById("CollectionListIconMinusInternational").hidden = true;
    document.getElementById("CollectionListIconPlusInternational").hidden = false;

    var IDList = window.localStorage.getItem('collection_IDList');
    var list = JSON.parse(window.localStorage.getItem("CollectionList"));
    var IDListCount = IDList.split(";");
    var tagsHTML = "";
    for (let i = 0; i < list.length; i++) {
        var IDUS = list[i].ID.toUpperCase() + "US";
        var IDInternational = list[i].ID.toUpperCase() + "International";
        if (document.getElementById(IDUS)) {
            document.getElementById(IDUS).hidden = true;
        }
        if (document.getElementById(IDInternational)) {
            document.getElementById(IDInternational).hidden = true;
        }
        for (let j = 0; j < IDListCount.length; j++) {
            if (list[i].URLCode == IDListCount[j]) {
                document.getElementById("CollectionListSubUS").hidden = false;
                document.getElementById("CollectionListIconMinusUS").hidden = false;
                document.getElementById("CollectionListIconPlusUS").hidden = true;

                document.getElementById("CollectionListSubInternational").hidden = false;
                document.getElementById("CollectionListIconMinusInternational").hidden = false;
                document.getElementById("CollectionListIconPlusInternational").hidden = true;

                document.getElementById("ProductListTags").hidden = false;

                if (document.getElementById(IDUS)) {
                    document.getElementById(IDUS).hidden = false;
                }
                if (document.getElementById(IDInternational)) {
                    document.getElementById(IDInternational).hidden = false;
                }
                tagsHTML = tagsHTML + "<span class='productFilter_content_tags_tag' id='CollectionMenu" + i + "'>";
                tagsHTML = tagsHTML + "<span style='color:#777777'>Collection: &nbsp;</span>";
                tagsHTML = tagsHTML + "<span>" + list[i].DisplayName + "</span>";
                tagsHTML = tagsHTML + "<i title='Close' class='icon-close' onclick='onCollectionTagClose(" + i + ")'></i>";
                tagsHTML = tagsHTML + "</span>";
            }
        }
    }
    document.getElementById('CollectionTags').innerHTML = tagsHTML;
    document.getElementById("ProductListLoader").hidden = true;
}
function getLifeStyleMenuItemsSub() {
    document.getElementById("ProductListLoader").hidden = false;

    document.getElementById("LifeStyleListSubUS").hidden = true;
    document.getElementById("LifeStyleListIconMinusUS").hidden = true;
    document.getElementById("LifeStyleListIconPlusUS").hidden = false;

    document.getElementById("LifeStyleListSubInternational").hidden = true;
    document.getElementById("LifeStyleListIconMinusInternational").hidden = true;
    document.getElementById("LifeStyleListIconPlusInternational").hidden = false;

    var IDList = window.localStorage.getItem('lifeStyle_IDList');
    var list = JSON.parse(window.localStorage.getItem("LifeStyleList"));
    var IDListCount = IDList.split(";");
    var tagsHTML = "";
    for (let i = 0; i < list.length; i++) {
        var IDUS = list[i].ID.toUpperCase() + "US";
        var IDInternational = list[i].ID.toUpperCase() + "International";
        if (document.getElementById(IDUS)) {
            document.getElementById(IDUS).hidden = true;
        }
        if (document.getElementById(IDInternational)) {
            document.getElementById(IDInternational).hidden = true;
        }
        for (let j = 0; j < IDListCount.length; j++) {
            if (list[i].URLCode == IDListCount[j]) {
                document.getElementById("LifeStyleListSubUS").hidden = false;
                document.getElementById("LifeStyleListIconMinusUS").hidden = false;
                document.getElementById("LifeStyleListIconPlusUS").hidden = true;

                document.getElementById("LifeStyleListSubInternational").hidden = false;
                document.getElementById("LifeStyleListIconMinusInternational").hidden = false;
                document.getElementById("LifeStyleListIconPlusInternational").hidden = true;

                document.getElementById("ProductListTags").hidden = false;

                if (document.getElementById(IDUS)) {
                    document.getElementById(IDUS).hidden = false;
                }
                if (document.getElementById(IDInternational)) {
                    document.getElementById(IDInternational).hidden = false;
                }

                tagsHTML = tagsHTML + "<span class='productFilter_content_tags_tag' id='LifeStyleMenu" + i + "'>";
                tagsHTML = tagsHTML + "<span style='color:#777777'>Life Style: &nbsp;</span>";
                tagsHTML = tagsHTML + "<span>" + list[i].DisplayName + "</span>";
                tagsHTML = tagsHTML + "<i title='Close' class='icon-close' onclick='onLifeStyleTagClose(" + i + ")'></i>";
                tagsHTML = tagsHTML + "</span>";
            }
        }
    }
    document.getElementById('LifeStyleTags').innerHTML = tagsHTML;
    document.getElementById("ProductListLoader").hidden = true;
}
function getStyleMenuItemsSub() {
    document.getElementById("ProductListLoader").hidden = false;

    document.getElementById("StyleListSubUS").hidden = true;
    document.getElementById("StyleListIconMinusUS").hidden = true;
    document.getElementById("StyleListIconPlusUS").hidden = false;

    document.getElementById("StyleListSubInternational").hidden = true;
    document.getElementById("StyleListIconMinusInternational").hidden = true;
    document.getElementById("StyleListIconPlusInternational").hidden = false;

    var IDList = window.localStorage.getItem('style_IDList');
    var list = JSON.parse(window.localStorage.getItem("StyleList"));
    var IDListCount = IDList.split(";");
    var tagsHTML = "";
    for (let i = 0; i < list.length; i++) {
        var IDUS = list[i].ID.toUpperCase() + "US";
        var IDInternational = list[i].ID.toUpperCase() + "International";
        if (document.getElementById(IDUS)) {
            document.getElementById(IDUS).hidden = true;
        }
        if (document.getElementById(IDInternational)) {
            document.getElementById(IDInternational).hidden = true;
        }
        for (let j = 0; j < IDListCount.length; j++) {
            if (list[i].URLCode == IDListCount[j]) {
                document.getElementById("StyleListSubUS").hidden = false;
                document.getElementById("StyleListIconMinusUS").hidden = false;
                document.getElementById("StyleListIconPlusUS").hidden = true;

                document.getElementById("StyleListSubInternational").hidden = false;
                document.getElementById("StyleListIconMinusInternational").hidden = false;
                document.getElementById("StyleListIconPlusInternational").hidden = true;

                document.getElementById("ProductListTags").hidden = false;



                if (document.getElementById(IDUS)) {
                    document.getElementById(IDUS).hidden = false;
                }
                if (document.getElementById(IDInternational)) {
                    document.getElementById(IDInternational).hidden = false;
                }

                tagsHTML = tagsHTML + "<span class='productFilter_content_tags_tag' id='StyleMenu" + i + "'>";
                tagsHTML = tagsHTML + "<span style='color:#777777'>Style: &nbsp;</span>";
                tagsHTML = tagsHTML + "<span>" + list[i].DisplayName + "</span>";
                tagsHTML = tagsHTML + "<i title='Close' class='icon-close' onclick='onStyleTagClose(" + i + ")'></i>";
                tagsHTML = tagsHTML + "</span>";
            }
        }
    }
    document.getElementById('StyleTags').innerHTML = tagsHTML;
    document.getElementById("ProductListLoader").hidden = true;
}
function getShapeMenuItemsSub() {
    document.getElementById("ProductListLoader").hidden = false;

    document.getElementById("ShapeListSubUS").hidden = true;
    document.getElementById("ShapeListIconMinusUS").hidden = true;
    document.getElementById("ShapeListIconPlusUS").hidden = false;

    document.getElementById("ShapeListSubInternational").hidden = true;
    document.getElementById("ShapeListIconMinusInternational").hidden = true;
    document.getElementById("ShapeListIconPlusInternational").hidden = false;

    var IDList = window.localStorage.getItem('shape_IDList');
    var list = JSON.parse(window.localStorage.getItem("ShapeList"));
    var IDListCount = IDList.split(";");
    var tagsHTML = "";
    for (let i = 0; i < list.length; i++) {
        var IDUS = list[i].ID.toUpperCase() + "US";
        var IDInternational = list[i].ID.toUpperCase() + "International";
        if (document.getElementById(IDUS)) {
            document.getElementById(IDUS).hidden = true;
        }
        if (document.getElementById(IDInternational)) {
            document.getElementById(IDInternational).hidden = true;
        }
        for (let j = 0; j < IDListCount.length; j++) {
            if (list[i].URLCode == IDListCount[j]) {
                document.getElementById("ShapeListSubUS").hidden = false;
                document.getElementById("ShapeListIconMinusUS").hidden = false;
                document.getElementById("ShapeListIconPlusUS").hidden = true;

                document.getElementById("ShapeListSubInternational").hidden = false;
                document.getElementById("ShapeListIconMinusInternational").hidden = false;
                document.getElementById("ShapeListIconPlusInternational").hidden = true;

                document.getElementById("ProductListTags").hidden = false;



                if (document.getElementById(IDUS)) {
                    document.getElementById(IDUS).hidden = false;
                }
                if (document.getElementById(IDInternational)) {
                    document.getElementById(IDInternational).hidden = false;
                }

                tagsHTML = tagsHTML + "<span class='productFilter_content_tags_tag' id='ShapeMenu" + i + "'>";
                tagsHTML = tagsHTML + "<span style='color:#777777'>Shape: &nbsp;</span>";
                tagsHTML = tagsHTML + "<span>" + list[i].DisplayName + "</span>";
                tagsHTML = tagsHTML + "<i title='Close' class='icon-close' onclick='onShapeTagClose(" + i + ")'></i>";
                tagsHTML = tagsHTML + "</span>";
            }
        }
    }
    document.getElementById('ShapeTags').innerHTML = tagsHTML;
    document.getElementById("ProductListLoader").hidden = true;
}
function getTypeMenuItemsSub() {
    document.getElementById("ProductListLoader").hidden = false;

    document.getElementById("RoomListSubUS").hidden = true;
    document.getElementById("RoomListIconMinusUS").hidden = true;
    document.getElementById("RoomListIconPlusUS").hidden = false;

    document.getElementById("RoomListSubInternational").hidden = true;
    document.getElementById("RoomListIconMinusInternational").hidden = true;
    document.getElementById("RoomListIconPlusInternational").hidden = false;


    var IDList = window.localStorage.getItem('type_IDList');
    var list = JSON.parse(window.localStorage.getItem("TypeList"));
    var IDListCount = IDList.split(";");
    var tagsHTML = "";
    for (let i = 0; i < list.length; i++) {
        var IDUS = list[i].ID.toUpperCase() + "US";
        var IDInternational = list[i].ID.toUpperCase() + "International";
        if (document.getElementById(IDUS)) {
            document.getElementById(IDUS).hidden = true;
        }
        if (document.getElementById(IDInternational)) {
            document.getElementById(IDInternational).hidden = true;
        }
        var roomIDUS = list[i].RoomAndUsage_ID.toUpperCase() + "US";
        var roomIDInternational = list[i].RoomAndUsage_ID.toUpperCase() + "International";
        for (let j = 0; j < IDListCount.length; j++) {
            if (list[i].URLCode == IDListCount[j]) {
                document.getElementById("RoomListSubUS").hidden = false;
                document.getElementById("RoomListIconMinusUS").hidden = false;
                document.getElementById("RoomListIconPlusUS").hidden = true;

                document.getElementById("RoomListSubInternational").hidden = false;
                document.getElementById("RoomListIconMinusInternational").hidden = false;
                document.getElementById("RoomListIconPlusInternational").hidden = true;

                document.getElementById("ProductListTags").hidden = false;

                if (document.getElementById(IDUS)) {
                    document.getElementById(IDUS).hidden = false;
                    if (document.getElementById(roomIDUS)) {
                        document.getElementById(roomIDUS).hidden = false;
                    }
                }
                if (document.getElementById(IDInternational)) {
                    document.getElementById(IDInternational).hidden = false;
                    if (document.getElementById(roomIDInternational)) {
                        document.getElementById(roomIDInternational).hidden = false;
                    }
                }

                tagsHTML = tagsHTML + "<span class='productFilter_content_tags_tag' id='TypeMenu" + i + "'>";
                tagsHTML = tagsHTML + "<span style='color:#777777'>Room: &nbsp;</span>";
                tagsHTML = tagsHTML + "<span>" + list[i].DisplayName + "</span>";
                tagsHTML = tagsHTML + "<i title='Close' class='icon-close' onclick='onTypeTagClose(" + i + ")'></i>";
                tagsHTML = tagsHTML + "</span>";
            }
        }
    }
    document.getElementById('TypeTags').innerHTML = tagsHTML;
    document.getElementById("ProductListLoader").hidden = true;
}
function getRoomMenuItemsSub() {
    document.getElementById("ProductListLoader").hidden = false;
    var IDList = window.localStorage.getItem('room_IDList');
    var list = JSON.parse(window.localStorage.getItem("RoomList"));
    var IDListCount = IDList.split(";");
    var tagsHTML = "";
    for (let i = 0; i < list.length; i++) {
        var IDUS = list[i].ID.toUpperCase() + "US";
        var IDInternational = list[i].ID.toUpperCase() + "International";
        if (document.getElementById(IDUS)) {
            document.getElementById(IDUS).hidden = true;
        }
        if (document.getElementById(IDInternational)) {
            document.getElementById(IDInternational).hidden = true;
        }
        for (let j = 0; j < IDListCount.length; j++) {
            if (list[i].URLCode == IDListCount[j]) {
                document.getElementById("ProductListTags").hidden = false;

                if (document.getElementById(IDUS)) {
                    document.getElementById(IDUS).hidden = false;
                }
                if (document.getElementById(IDInternational)) {
                    document.getElementById(IDInternational).hidden = false;
                }

                tagsHTML = tagsHTML + "<span class='productFilter_content_tags_tag' id='RoomMenu" + i + "'>";
                tagsHTML = tagsHTML + "<span style='color:#777777'>Room: &nbsp;</span>";
                tagsHTML = tagsHTML + "<span>" + list[i].DisplayName + "</span>";
                tagsHTML = tagsHTML + "<i title='Close' class='icon-close' onclick='onRoomTagClose(" + i + ")'></i>";
                tagsHTML = tagsHTML + "</span>";
            }
        }
    }
    document.getElementById('RoomTags').innerHTML = tagsHTML;
    document.getElementById("ProductListLoader").hidden = true;
}
function getBrandMenuItemsSub() {
    document.getElementById("ProductListLoader").hidden = false;
    var IDList = window.localStorage.getItem('brand_IDList');
    var list = JSON.parse(window.localStorage.getItem("BrandList"));
    var IDListCount = IDList.split(";");
    var tagsHTML = "";
    for (let i = 0; i < list.length; i++) {
        var IDUS = list[i].ID.toUpperCase() + "US";
        var IDInternational = list[i].ID.toUpperCase() + "International";
        if (document.getElementById(IDUS)) {
            document.getElementById(IDUS).hidden = true;
        }
        if (document.getElementById(IDInternational)) {
            document.getElementById(IDInternational).hidden = true;
        }
        for (let j = 0; j < IDListCount.length; j++) {
            if (list[i].URLCode == IDListCount[j]) {
                document.getElementById("ProductListTags").hidden = false;


                if (document.getElementById(IDUS)) {
                    document.getElementById(IDUS).hidden = false;
                }
                if (document.getElementById(IDInternational)) {
                    document.getElementById(IDInternational).hidden = false;
                }

                tagsHTML = tagsHTML + "<span class='productFilter_content_tags_tag' id='RoomMenu" + i + "'>";
                tagsHTML = tagsHTML + "<span style='color:#777777'>Brand: &nbsp;</span>";
                tagsHTML = tagsHTML + "<span>" + list[i].DisplayName + "</span>";
                tagsHTML = tagsHTML + "<i title='Close' class='icon-close' onclick='onRoomTagClose(" + i + ")'></i>";
                tagsHTML = tagsHTML + "</span>";
            }
        }
    }
    document.getElementById('BrandTags').innerHTML = tagsHTML;
    document.getElementById("ProductListLoader").hidden = true;
}
function getDesignerMenuItemsSub() {
    document.getElementById("ProductListLoader").hidden = false;
    var IDList = window.localStorage.getItem('designer_IDList');
    var list = JSON.parse(window.localStorage.getItem("DesignerList"));
    var IDListCount = IDList.split(";");
    var tagsHTML = "";
    for (let i = 0; i < list.length; i++) {
        var IDUS = list[i].ID.toUpperCase() + "US";
        var IDInternational = list[i].ID.toUpperCase() + "International";
        if (document.getElementById(IDUS)) {
            document.getElementById(IDUS).hidden = true;
        }
        if (document.getElementById(IDInternational)) {
            document.getElementById(IDInternational).hidden = true;
        }
        for (let j = 0; j < IDListCount.length; j++) {
            if (list[i].URLCode == IDListCount[j]) {
                document.getElementById("ProductListTags").hidden = false;

                if (document.getElementById(IDUS)) {
                    document.getElementById(IDUS).hidden = false;
                }
                if (document.getElementById(IDInternational)) {
                    document.getElementById(IDInternational).hidden = false;
                }

                tagsHTML = tagsHTML + "<span class='productFilter_content_tags_tag' id='Designer" + i + "'>";
                tagsHTML = tagsHTML + "<span style='color:#777777'>Designer: &nbsp;</span>";
                tagsHTML = tagsHTML + "<span>" + list[i].DisplayName + "</span>";
                tagsHTML = tagsHTML + "<i title='Close' class='icon-close' onclick='onDesignerTagClose(" + i + ")'></i>";
                tagsHTML = tagsHTML + "</span>";
            }
        }
    }
    document.getElementById('DesignerTags').innerHTML = tagsHTML;
    document.getElementById("ProductListLoader").hidden = true;
}
function getByQueryString001() {
    checkClearAll();
    document.getElementById("ProductListLoader").hidden = false;
    document.getElementById("ProductListProductsUS").hidden = true;
    document.getElementById("ProductListProductsInternational").hidden = true;
    document.getElementById("ProductListProductsLoad").hidden = true;
    document.getElementById("ProductListResultEmpty").hidden = true;
    var user_ID = window.localStorage.getItem('UserID');
    var region = window.localStorage.getItem('Region');
    var room_IDList = window.localStorage.getItem('room_IDList');
    var brand_IDList = window.localStorage.getItem('brand_IDList');
    var type_IDList = window.localStorage.getItem('type_IDList');
    var shape_IDList = window.localStorage.getItem('shape_IDList');
    var style_IDList = window.localStorage.getItem('style_IDList');
    var lifeStyle_IDList = window.localStorage.getItem('lifeStyle_IDList');
    var collection_IDList = window.localStorage.getItem('collection_IDList');
    var designer_IDList = window.localStorage.getItem('designer_IDList');
    var searchString = window.localStorage.getItem('searchString');
    var extending = window.localStorage.getItem('extending');
    var isStocked = window.localStorage.getItem('isStocked');
    var isCFPItem = window.localStorage.getItem('isCFPItem');
    if ((user_ID == null) || (user_ID.length == 0) || (user_ID.toUpperCase() == "UNDEFINED")) {
        user_ID = "00000000-0000-0000-0000-000000000000";
    }
    if ((region == null) || (region.length == 0)) {
        region = "TAUS";
    }
    if ((room_IDList == null) || (room_IDList.length == 0)) {
        room_IDList = ";";
    }
    if ((brand_IDList == null) || (brand_IDList.length == 0)) {
        brand_IDList = ";";
    }
    if ((type_IDList == null) || (type_IDList.length == 0)) {
        type_IDList = ";";
    }
    if ((shape_IDList == null) || (shape_IDList.length == 0)) {
        shape_IDList = ";";
    }
    if ((style_IDList == null) || (style_IDList.length == 0)) {
        style_IDList = ";";
    }
    if ((lifeStyle_IDList == null) || (lifeStyle_IDList.length == 0)) {
        lifeStyle_IDList = ";";
    }
    if ((collection_IDList == null) || (collection_IDList.length == 0)) {
        collection_IDList = ";";
    }
    if ((designer_IDList == null) || (designer_IDList.length == 0)) {
        designer_IDList = ";";
    }
    if ((searchString == null) || (searchString.length == 0)) {
        searchString = "";
    }
    if (searchString) {
        document.getElementById("BodySearchString").value = searchString;
        document.getElementById("BodySearchStringMobile").value = searchString;
    }
    var url = "http://api-test.theodorealexander.com/api/Item/AsyncGetDataTransferByUser_IDAndRegionAndFiltersToList";
    $.ajax({
        type: "GET",
        url: url,
        data: {
            "user_ID": user_ID,
            "region": region,
            "room_IDList": room_IDList,
            "brand_IDList": brand_IDList,
            "type_IDList": type_IDList,
            "shape_IDList": shape_IDList,
            "style_IDList": style_IDList,
            "lifeStyle_IDList": lifeStyle_IDList,
            "collection_IDList": collection_IDList,
            "designer_IDList": designer_IDList,
            "searchString": searchString,
            "extending": extending,
            "isStocked": isStocked,
            "isCFPItem": isCFPItem
        },
        headers: {
            "Ip_Address": '172.18.3.74',
            "API_KEY": 'X-some-key',
            'Authorization': ''
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var list = data.Data;
            window.localStorage.setItem("ProductListData", JSON.stringify(list));
            onSortBy(1);
            onGetMenuLeft();
            document.getElementById("ProductListLoader").hidden = true;
        },
        error: function (err) {
            document.getElementById("ProductListLoader").hidden = true;
        }
    });
}
function onSortBy(sortBy) {
    window.localStorage.setItem('SortBy', sortBy);
    document.getElementById("ProductListLoader").hidden = false;
    var list = JSON.parse(window.localStorage.getItem("ProductListData"));
    if (list) {
        document.getElementById("ProductListUSResults").innerHTML = list.length;
        document.getElementById("ProductListInternationalResults").innerHTML = list.length;
        if (list.length == 0) {
            document.getElementById("ProductListResultEmpty").hidden = false;
        }
        else {
            document.getElementById("ProductListResultEmpty").hidden = true;
            switch (sortBy) {
                case "1":
                    list = list.sort(GetSortOrderDESC("IsNew"));
                    break;
                case "2":
                    list = list.sort(GetSortOrderDESC("IsBestSeller"));
                    break;
                case "3":
                    list = list.sort(GetSortOrderASC("ProductName"));
                    break;
                case "4":
                    list = list.sort(GetSortOrderDESC("ProductName"));
                    break;
            }
            initializationProductListHTML(list);
        }
    }
    else {
        document.getElementById("ProductListResultEmpty").hidden = false;
        document.getElementById("ProductListUSResults").innerHTML = "0";
        document.getElementById("ProductListInternationalResults").innerHTML = "0";
    }
    document.getElementById("ProductListLoader").hidden = true;
}
function GetSortOrderASC(prop) {
    return function (a, b) {
        if (a[prop] > b[prop]) {
            return 1;
        } else if (a[prop] < b[prop]) {
            return -1;
        }
        return 0;
    }
}
function GetSortOrderDESC(prop) {
    return function (a, b) {
        if (a[prop] < b[prop]) {
            return 1;
        } else if (a[prop] > b[prop]) {
            return -1;
        }
        return 0;
    }
}
function initializationProductListHTML(list) {
    var productListHTML = "";
    var count = list.length;
    if (count > 60) {
        count = 60
    }
    for (var i = 0; i < count; i++) {
        productListHTML = productListHTML + "<div class='product'>";
        productListHTML = productListHTML + "<div class='tags'>";
        if (list[i].IsCFPItem) {
            productListHTML = productListHTML + "<img src='http://web-test.theodorealexander.com/assets/img/CP-icon.png' class='pic-icon-cp'>";
        }
        if (list[i].IsAXHCFPItem) {
            productListHTML = productListHTML + "<img src='http://web-test.theodorealexander.com/assets/img/icon-AXH.png' class='pic-icon-axh'>";
        }
        if (list[i].IsNew) {
            productListHTML = productListHTML + "<span class='tag'>New</span>";
        }
        productListHTML = productListHTML + "</div>";
        productListHTML = productListHTML + "<div class='info'>";
        productListHTML = productListHTML + "<div class='image'>";
        productListHTML = productListHTML + "<a href='http://web-test.theodorealexander.com/product-detail/" + list[i].URLCode + ".html' title='" + list[i].ProductName + "'>";
        productListHTML = productListHTML + "<img src='" + list[i].ImageSirv + "?w=400&amp;h=400' title='" + list[i].ProductName + "' alt='" + list[i].ProductName + "' />";
        productListHTML = productListHTML + "</a>";
        productListHTML = productListHTML + "</div>";
        productListHTML = productListHTML + "<div class='name'>";
        productListHTML = productListHTML + "<a href='http://web-test.theodorealexander.com/product-detail/" + list[i].URLCode + ".html' title='" + list[i].ProductName + "'>";
        productListHTML = productListHTML + "<h4>" + list[i].ProductName + "</h4>";
        productListHTML = productListHTML + "</a>";
        productListHTML = productListHTML + "<div class='sku'>" + list[i].SKU + "</div>";
        productListHTML = productListHTML + "<div class='addtowish'>";
        if (list[i].IsInWishList) {
            productListHTML = productListHTML + "<i class='icon-heart_fill'></i>";
        }
        else {
            productListHTML = productListHTML + "<i id='" + list[i].ID.toUpperCase() + "Wishlist' title='Add wishlist' class='icon-heart_outline' onclick='onOpenAddToWishlist(" + i + ")'></i>";
        }
        productListHTML = productListHTML + "</div>";
        productListHTML = productListHTML + "<div hidden class='productFilter_content_productList_row_product_caption_description'>";
        productListHTML = productListHTML + "" + list[i].ExtendedDescription;
        productListHTML = productListHTML + "</div>";
        productListHTML = productListHTML + "</div>";
        productListHTML = productListHTML + "<div hidden class='productFilter_content_productList_row_product_themestyle'>";
        productListHTML = productListHTML + "<b>Brand:</b> " + list[i].BrandName + "<br />";
        productListHTML = productListHTML + "<b>Collection:</b> " + list[i].CollectionName + "<br />";
        productListHTML = productListHTML + "<b>Room:</b> " + list[i].RoomAndUsageName + "<br />";
        productListHTML = productListHTML + "<b>Type:</b> " + list[i].TypeName;
        productListHTML = productListHTML + "</div>";
        productListHTML = productListHTML + "</div>";
        productListHTML = productListHTML + "</div>";
    }
    document.getElementById('ProductListProductsLoad').innerHTML = productListHTML;
    document.getElementById("ProductListProductsUS").hidden = true;
    document.getElementById("ProductListProductsInternational").hidden = true;
    document.getElementById("ProductListProductsLoad").hidden = false;
}
function onInitializationProductListData() {
    checkClearAll();
    document.getElementById("ProductListLoader").hidden = false;
    var user_ID = window.localStorage.getItem('UserID');
    var region = window.localStorage.getItem('Region');
    var room_IDList = window.localStorage.getItem('room_IDList');
    var brand_IDList = window.localStorage.getItem('brand_IDList');
    var type_IDList = window.localStorage.getItem('type_IDList');
    var shape_IDList = window.localStorage.getItem('shape_IDList');
    var style_IDList = window.localStorage.getItem('style_IDList');
    var lifeStyle_IDList = window.localStorage.getItem('lifeStyle_IDList');
    var collection_IDList = window.localStorage.getItem('collection_IDList');
    var designer_IDList = window.localStorage.getItem('designer_IDList');
    var searchString = window.localStorage.getItem('searchString');
    var extending = window.localStorage.getItem('extending');
    var isStocked = window.localStorage.getItem('isStocked');
    var isCFPItem = window.localStorage.getItem('isCFPItem');
    if ((user_ID == null) || (user_ID.length == 0) || (user_ID.toUpperCase() == "UNDEFINED")) {
        user_ID = "00000000-0000-0000-0000-000000000000";
    }
    if ((region == null) || (region.length == 0)) {
        region = "TAUS";
    }
    if ((room_IDList == null) || (room_IDList.length == 0)) {
        room_IDList = ";";
    }
    if ((brand_IDList == null) || (brand_IDList.length == 0)) {
        brand_IDList = ";";
    }
    if ((type_IDList == null) || (type_IDList.length == 0)) {
        type_IDList = ";";
    }
    if ((shape_IDList == null) || (shape_IDList.length == 0)) {
        shape_IDList = ";";
    }
    if ((style_IDList == null) || (style_IDList.length == 0)) {
        style_IDList = ";";
    }
    if ((lifeStyle_IDList == null) || (lifeStyle_IDList.length == 0)) {
        lifeStyle_IDList = ";";
    }
    if ((collection_IDList == null) || (collection_IDList.length == 0)) {
        collection_IDList = ";";
    }
    if ((designer_IDList == null) || (designer_IDList.length == 0)) {
        designer_IDList = ";";
    }
    if ((searchString == null) || (searchString.length == 0)) {
        searchString = "";
    }
    var url = "http://api-test.theodorealexander.com/api/Item/AsyncGetDataTransferByUser_IDAndRegionAndFiltersToList";
    $.ajax({
        type: "GET",
        url: url,
        data: {
            "user_ID": user_ID,
            "region": region,
            "room_IDList": room_IDList,
            "brand_IDList": brand_IDList,
            "type_IDList": type_IDList,
            "shape_IDList": shape_IDList,
            "style_IDList": style_IDList,
            "lifeStyle_IDList": lifeStyle_IDList,
            "collection_IDList": collection_IDList,
            "designer_IDList": designer_IDList,
            "searchString": searchString,
            "extending": extending,
            "isStocked": isStocked,
            "isCFPItem": isCFPItem
        },
        headers: {
            "Ip_Address": '172.18.3.74',
            "API_KEY": 'X-some-key',
            'Authorization': ''
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var list = data.Data;
            window.localStorage.setItem("ProductListData", JSON.stringify(list));
            if (user_ID != '00000000-0000-0000-0000-000000000000') {
                for (var i = 0; i < list.length; i++) {
                    if (list[i].IsInWishList) {
                        var itemIDWishlist = list[i].ID.toUpperCase() + "Wishlist";
                        document.getElementById(itemIDWishlist).className = '';
                        document.getElementById(itemIDWishlist).classList.add("icon-heart_fill");
                    }
                }
            }
            document.getElementById("ProductListLoader").hidden = true;
        },
        error: function (err) {
            document.getElementById("ProductListLoader").hidden = true;
        }
    });
}
function onCloseAddToWishlist() {
    var modal = document.getElementById("modalAddToWWishlist");
    modal.style.display = "none";
}
function onOpenAddToWishlist(index) {
    var list = JSON.parse(window.localStorage.getItem("ProductListData"));
    var itemID = list[index].ID;
    var itemName = list[index].ProductName;
    window.localStorage.setItem('ItemID', itemID);
    window.localStorage.setItem('ItemIndex', index);
    if (itemName) {
        if (itemName.length > 0) {
            window.localStorage.setItem('ItemName', itemName);
        }
    }
    var modal = document.getElementById("modalAddToWWishlist");
    modal.style.display = "block";
    onGetWishlistByUserID();
}
function onAddToWishlist(index) {
    var list = JSON.parse(window.localStorage.getItem("WishlistByUserID"));
    if (list) {
        var wishListID = list[index].ID;
        var wishListName = list[index].Name;
        var userID = window.localStorage.getItem('UserID');
        var itemID = window.localStorage.getItem('ItemID');
        var itemName = window.localStorage.getItem('ItemName');
        if ((userID) && (wishListID) && (itemID)) {
            var url = "http://api-test.theodorealexander.com/api/WishList/AddItemToWishListByUserIDAndWishListIDAndItemID";
            $.ajax({
                type: "GET",
                url: url,
                data: {
                    "userID": userID,
                    "wishListID": wishListID,
                    "itemID": itemID,
                },
                headers: {
                    "Ip_Address": '172.18.3.74',
                    "API_KEY": 'X-some-key',
                    'Authorization': ''
                },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var list = data.Data;
                    document.getElementById("WishlistNote").innerHTML = "Added " + itemName + " to " + wishListName;
                    document.getElementById(wishListID).style.backgroundColor = "#ffe4c4";
                    var itemIDWishlist = itemID + "Wishlist";
                    document.getElementById(itemIDWishlist).className = '';
                    document.getElementById(itemIDWishlist).classList.add("icon-heart_fill");
                },
                error: function (err) {
                }
            });
        }
    }
}
function onAddToWishlistByWishListID(wishListID, wishListName) {
    var userID = window.localStorage.getItem('UserID');
    var itemID = window.localStorage.getItem('ItemID');
    var itemName = window.localStorage.getItem('ItemName');
    if ((userID) && (wishListID) && (itemID)) {
        var url = "http://api-test.theodorealexander.com/api/WishList/AddItemToWishListByUserIDAndWishListIDAndItemID";
        $.ajax({
            type: "GET",
            url: url,
            data: {
                "userID": userID,
                "wishListID": wishListID,
                "itemID": itemID,
            },
            headers: {
                "Ip_Address": '172.18.3.74',
                "API_KEY": 'X-some-key',
                'Authorization': ''
            },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var list = data.Data;
                document.getElementById("WishlistNote").innerHTML = "Added <b>" + itemName + "</b> to <b>" + wishListName + "</b>";
                document.getElementById(wishListID).style.backgroundColor = "#ffe4c4";
                var itemIDWishlist = itemID + "Wishlist";
                document.getElementById(itemIDWishlist).className = '';
                document.getElementById(itemIDWishlist).classList.add("icon-heart_fill");
            },
            error: function (err) {
            }
        });
    }
}
function onSaveToWishlist() {
    var itemIndex = window.localStorage.getItem('ItemIndex');
    var wishlistName = document.getElementById("txtWishlistName").value;
    if (wishlistName) {
        var userID = window.localStorage.getItem('UserID');
        var URLCheck = window.localStorage.getItem('URLCheck');
        var url = "http://web-test.theodorealexander.com/checklogin/" + URLCheck + "_" + itemIndex;
        if ((userID == null) || (userID.length == 0) || (userID.toUpperCase() == "UNDEFINED") || (userID.toUpperCase() == "00000000-0000-0000-0000-000000000000")) {
            window.location.href = url;
        }
        if (userID) {
            var url = "http://api-test.theodorealexander.com/api/WishList/AddWishListByUserIDAndWishlistName";
            $.ajax({
                type: "GET",
                url: url,
                data: {
                    "userID": userID,
                    "wishlistName": wishlistName
                },
                headers: {
                    "Ip_Address": '172.18.3.74',
                    "API_KEY": 'X-some-key',
                    'Authorization': ''
                },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var list = data.Data;
                    onGetWishlistByUserID();
                    onAddToWishlistByWishListID(list.ID, list.Name);
                },
                error: function (err) {
                }
            });
        }
    }
}
function onGetWishlistByUserID() {
    var userID = window.localStorage.getItem('UserID');
    var itemIndex = window.localStorage.getItem('ItemIndex');
    var URLCheck = window.localStorage.getItem('URLCheck');
    var url = "http://web-test.theodorealexander.com/checklogin/" + URLCheck + "_" + itemIndex;
    if ((userID == null) || (userID.length == 0) || (userID.toUpperCase() == "UNDEFINED") || (userID.toUpperCase() == "00000000-0000-0000-0000-000000000000")) {
        window.location.href = url;
    }
    if (userID) {
        var url = "http://api-test.theodorealexander.com/api/WishList/GetWishListByUserID";
        $.ajax({
            type: "GET",
            url: url,
            data: {
                "userID": userID
            },
            headers: {
                "Ip_Address": '172.18.3.74',
                "API_KEY": 'X-some-key',
                'Authorization': ''
            },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var list = data.Data;
                window.localStorage.setItem("WishlistByUserID", JSON.stringify(list));
                if (list) {
                    if (list.length > 0) {
                        var wishlistByUserIDHTML = "";
                        for (var i = 0; i < list.length; i++) {
                            wishlistByUserIDHTML = wishlistByUserIDHTML + "<li style='cursor: pointer;' onclick='onAddToWishlist(" + i + ")'>";
                            wishlistByUserIDHTML = wishlistByUserIDHTML + "<div class='main_name_wishlist_popup' style='padding-left: 20px;'>";
                            wishlistByUserIDHTML = wishlistByUserIDHTML + list[i].Name;
                            wishlistByUserIDHTML = wishlistByUserIDHTML + "<span class='selected_wishlist_popup' style='position: absolute; right: 50px; margin-top:0px;'>";
                            wishlistByUserIDHTML = wishlistByUserIDHTML + "<input type='radio' name='radio'>";
                            wishlistByUserIDHTML = wishlistByUserIDHTML + "<span id='" + list[i].ID + "' class='checkmark'></span>";
                            wishlistByUserIDHTML = wishlistByUserIDHTML + "</span>";
                            wishlistByUserIDHTML = wishlistByUserIDHTML + "</div>";
                            wishlistByUserIDHTML = wishlistByUserIDHTML + "</li>";
                        }
                        document.getElementById('WishlistByUserID').innerHTML = wishlistByUserIDHTML;
                    }
                }
            },
            error: function (err) {
            }
        });
    }
}
function onWishlistNameKeyUp() {
    var wishlistName = document.getElementById("txtWishlistName").value;
    if (wishlistName) {
        document.getElementById("btnWishlistName").disabled = false;
        document.getElementById("btnWishlistName").className = '';
        document.getElementById("btnWishlistName").classList.add("btn_add_wishlist_popup");
    }
}
function onOpenSortBy() {
    var hidden = document.getElementById("SortBySelectedList").hidden;
    hidden = !hidden;
    document.getElementById("SortBySelectedList").hidden = hidden;
}
function onSortBySelected(index, name) {
    document.getElementById("SortBySelectedList").hidden = true;
    document.getElementById("SortBySelectedName").innerHTML = name;
    onSortBy(index);
}
function onOpenSortByMobile() {
    var hidden = document.getElementById("SortBySelectedListMobile").hidden;
    hidden = !hidden;
    document.getElementById("SortBySelectedListMobile").hidden = hidden;
}
function onSortBySelectedMobile(index, name) {
    document.getElementById("SortBySelectedListMobile").hidden = true;
    document.getElementById("SortBySelectedNameMobile").innerHTML = name;
    onSortBy(index);
}
$(window).scroll(function () {
    if ($(window).scrollTop() + $(window).height() > $(document).height() - 200) {
        var sortBy = window.localStorage.getItem('SortBy');
        onSortByPageEnd(sortBy);
    }
});
function onSortByPageEnd(sortBy) {
    window.localStorage.setItem('SortBy', sortBy);
    document.getElementById("ProductListLoader").hidden = false;
    var list = JSON.parse(window.localStorage.getItem("ProductListData"));
    if (list) {
        document.getElementById("ProductListUSResults").innerHTML = list.length;
        document.getElementById("ProductListInternationalResults").innerHTML = list.length;
        if (list.length == 0) {
            document.getElementById("ProductListResultEmpty").hidden = false;
        }
        else {
            document.getElementById("ProductListResultEmpty").hidden = true;
            switch (sortBy) {
                case "1":
                    list = list.sort(GetSortOrderDESC("IsNew"));
                    break;
                case "2":
                    list = list.sort(GetSortOrderDESC("IsBestSeller"));
                    break;
                case "3":
                    list = list.sort(GetSortOrderASC("ProductName"));
                    break;
                case "4":
                    list = list.sort(GetSortOrderDESC("ProductName"));
                    break;
            }
            initializationProductListHTMLByPageEnd(list);
        }
    }
    else {
        document.getElementById("ProductListResultEmpty").hidden = false;
        document.getElementById("ProductListUSResults").innerHTML = "0";
        document.getElementById("ProductListInternationalResults").innerHTML = "0";
    }
    document.getElementById("ProductListLoader").hidden = true;
}
function initializationProductListHTMLByPageEnd(list) {
    var productListHTML = "";
    var count = list.length;
    for (var i = 0; i < count; i++) {
        productListHTML = productListHTML + "<div class='product'>";
        productListHTML = productListHTML + "<div class='tags'>";
        if (list[i].IsCFPItem) {
            productListHTML = productListHTML + "<img src='http://web-test.theodorealexander.com/assets/img/CP-icon.png' class='pic-icon-cp'>";
        }
        if (list[i].IsAXHCFPItem) {
            productListHTML = productListHTML + "<img src='http://web-test.theodorealexander.com/assets/img/icon-AXH.png' class='pic-icon-axh'>";
        }
        if (list[i].IsNew) {
            productListHTML = productListHTML + "<span class='tag'>New</span>";
        }
        productListHTML = productListHTML + "</div>";
        productListHTML = productListHTML + "<div class='info'>";
        productListHTML = productListHTML + "<div class='image'>";
        productListHTML = productListHTML + "<a href='http://web-test.theodorealexander.com/product-detail/" + list[i].URLCode + ".html' title='" + list[i].ProductName + "'>";
        productListHTML = productListHTML + "<img src='" + list[i].ImageSirv + "?w=400&amp;h=400' title='" + list[i].ProductName + "' alt='" + list[i].ProductName + "' />";
        productListHTML = productListHTML + "</a>";
        productListHTML = productListHTML + "</div>";
        productListHTML = productListHTML + "<div class='name'>";
        productListHTML = productListHTML + "<a href='http://web-test.theodorealexander.com/product-detail/" + list[i].URLCode + ".html' title='" + list[i].ProductName + "'>";
        productListHTML = productListHTML + "<h4>" + list[i].ProductName + "</h4>";
        productListHTML = productListHTML + "</a>";
        productListHTML = productListHTML + "<div class='sku'>" + list[i].SKU + "</div>";
        productListHTML = productListHTML + "<div class='addtowish'>";
        if (list[i].IsInWishList) {
            productListHTML = productListHTML + "<i class='icon-heart_fill'></i>";
        }
        else {
            productListHTML = productListHTML + "<i id='" + list[i].ID.toUpperCase() + "Wishlist' title='Add wishlist' class='icon-heart_outline' onclick='onOpenAddToWishlist(" + i + ")'></i>";
        }
        productListHTML = productListHTML + "</div>";
        productListHTML = productListHTML + "<div hidden class='productFilter_content_productList_row_product_caption_description'>";
        productListHTML = productListHTML + "" + list[i].ExtendedDescription;
        productListHTML = productListHTML + "</div>";
        productListHTML = productListHTML + "</div>";
        productListHTML = productListHTML + "<div hidden class='productFilter_content_productList_row_product_themestyle'>";
        productListHTML = productListHTML + "<b>Brand:</b> " + list[i].BrandName + "<br />";
        productListHTML = productListHTML + "<b>Collection:</b> " + list[i].CollectionName + "<br />";
        productListHTML = productListHTML + "<b>Room:</b> " + list[i].RoomAndUsageName + "<br />";
        productListHTML = productListHTML + "<b>Type:</b> " + list[i].TypeName;
        productListHTML = productListHTML + "</div>";
        productListHTML = productListHTML + "</div>";
        productListHTML = productListHTML + "</div>";
    }
    document.getElementById('ProductListProductsLoad').innerHTML = productListHTML;
    document.getElementById("ProductListProductsUS").hidden = true;
    document.getElementById("ProductListProductsInternational").hidden = true;
    document.getElementById("ProductListProductsLoad").hidden = false;
}
function onGetMenuLeft() {
    document.getElementById("ProductListLoader").hidden = false;
    var user_ID = window.localStorage.getItem('UserID');
    var region = window.localStorage.getItem('Region');
    var room_IDList = window.localStorage.getItem('room_IDList');
    var brand_IDList = window.localStorage.getItem('brand_IDList');
    var type_IDList = window.localStorage.getItem('type_IDList');
    var shape_IDList = window.localStorage.getItem('shape_IDList');
    var style_IDList = window.localStorage.getItem('style_IDList');
    var lifeStyle_IDList = window.localStorage.getItem('lifeStyle_IDList');
    var collection_IDList = window.localStorage.getItem('collection_IDList');
    var designer_IDList = window.localStorage.getItem('designer_IDList');
    var searchString = window.localStorage.getItem('searchString');
    var extending = window.localStorage.getItem('extending');
    var isStocked = window.localStorage.getItem('isStocked');
    var isCFPItem = window.localStorage.getItem('isCFPItem');
    if ((user_ID == null) || (user_ID.length == 0) || (user_ID.toUpperCase() == "UNDEFINED")) {
        user_ID = "00000000-0000-0000-0000-000000000000";
    }
    if ((region == null) || (region.length == 0)) {
        region = "TAUS";
    }
    if ((room_IDList == null) || (room_IDList.length == 0)) {
        room_IDList = ";";
    }
    if ((brand_IDList == null) || (brand_IDList.length == 0)) {
        brand_IDList = ";";
    }
    if ((type_IDList == null) || (type_IDList.length == 0)) {
        type_IDList = ";";
    }
    if ((shape_IDList == null) || (shape_IDList.length == 0)) {
        shape_IDList = ";";
    }
    if ((style_IDList == null) || (style_IDList.length == 0)) {
        style_IDList = ";";
    }
    if ((lifeStyle_IDList == null) || (lifeStyle_IDList.length == 0)) {
        lifeStyle_IDList = ";";
    }
    if ((collection_IDList == null) || (collection_IDList.length == 0)) {
        collection_IDList = ";";
    }
    if ((designer_IDList == null) || (designer_IDList.length == 0)) {
        designer_IDList = ";";
    }
    if ((searchString == null) || (searchString.length == 0)) {
        searchString = "";
    }
    var url = "http://api-test.theodorealexander.com/api/Item/AsyncGetItemMenuLeftDataTransferByUser_IDAndIsActiveTAUSAndFiltersToList";
    $.ajax({
        type: "GET",
        url: url,
        data: {
            "user_ID": user_ID,
            "region": region,
            "room_IDList": room_IDList,
            "brand_IDList": brand_IDList,
            "type_IDList": type_IDList,
            "shape_IDList": shape_IDList,
            "style_IDList": style_IDList,
            "lifeStyle_IDList": lifeStyle_IDList,
            "collection_IDList": collection_IDList,
            "designer_IDList": designer_IDList,
            "searchString": searchString,
            "extending": extending,
            "isStocked": isStocked,
            "isCFPItem": isCFPItem
        },
        headers: {
            "Ip_Address": '172.18.3.74',
            "API_KEY": 'X-some-key',
            'Authorization': ''
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var listMenuLeft = data.Data;
            window.localStorage.setItem("MenuLeftData", JSON.stringify(listMenuLeft));
            onCheckMenuLeft();
            document.getElementById("ProductListLoader").hidden = true;
        },
        error: function (err) {
            document.getElementById("ProductListLoader").hidden = true;
        }
    });
}
function onCheckMenuLeft() {
    var region = window.localStorage.getItem('Region');
    if (region == 'TAUS') {
        region = 'US';
    }
    var nowClick = window.localStorage.getItem("NowClick");
    var menuLeftList = JSON.parse(window.localStorage.getItem("MenuLeftData"));
    var roomCount = 0;
    var typeCount = 0;
    var collectionCount = 0;
    var lifeStyleCount = 0;
    var styleCount = 0;
    var shapeCount = 0;
    var extendingCount = 0;
    var livingCount = 0;
    var diningCount = 0;
    var bedCount = 0;
    var officeCount = 0;
    var lightingCount = 0;
    var decorCount = 0;
    var type = "Type";
    var collection = "Collection";
    var lifeStyle = "LifeStyle";
    var style = "Style";
    var shape = "Shape";
    var roomAndUsage = "RoomAndUsage";
    var extending = "Extending";
    var livingID = "EE6344A6-D565-4DF1-A77E-DB67F134B210";
    var diningID = "02812CCF-77D7-4C48-92EC-3C1443C1A9B6";
    var bedID = "DBE311AC-8E4F-4A72-BCD0-D60CE0F196D1";
    var officeID = "E3185E73-CB9B-48C4-AFBE-2BFB757B217F";
    var lightingID = "B7E020EC-84BF-4A2D-B250-6724EEEE3B10";
    var decorID = "C441230F-C2CE-4744-AAEC-40C0A942D79C";
    for (var j = 0; j < menuLeftList.length; j++) {
        var ID = menuLeftList[j].ID.toUpperCase() + "Li" + region;
        var IDCount = menuLeftList[j].ID.toUpperCase() + "ItemCount" + region;
        var IDCountFilter = menuLeftList[j].ID.toUpperCase() + "ItemCount" + region + "Filter";
        if (document.getElementById(ID)) {
            var countFilter = Number(document.getElementById(IDCountFilter).innerHTML);
            if (countFilter > 0) {
                document.getElementById(IDCount).innerHTML = document.getElementById(IDCountFilter).innerHTML;
            }
            document.getElementById(IDCountFilter).innerHTML = menuLeftList[j].ItemCount;
            document.getElementById(IDCountFilter).hidden = false;
            document.getElementById(IDCount).hidden = true;
            if (menuLeftList[j].ItemCount == 0) {
                if (menuLeftList[j].Category != nowClick) {
                    document.getElementById(ID).hidden = true;
                }
                else {
                    document.getElementById(IDCountFilter).hidden = true;
                    document.getElementById(IDCount).hidden = false;
                }
                if ((menuLeftList[j].Category == roomAndUsage) && (nowClick == type)) {
                    document.getElementById(ID).hidden = false;
                }
            }
            else {
                document.getElementById(ID).hidden = false;
            }
            if (document.getElementById(ID).hidden == false) {
                //if (menuLeftList[j].Category == roomAndUsage) {
                //    if (menuLeftList[j].ItemCount > 0) {
                //        roomCount = roomCount + menuLeftList[j].ItemCount;
                //    }
                //    else {
                //        roomCount = roomCount + Number(document.getElementById(IDCount).innerHTML);
                //    }
                //}
                if (menuLeftList[j].Category == type) {
                    var itemCount = 0
                    if (menuLeftList[j].ItemCount > 0) {
                        itemCount = menuLeftList[j].ItemCount;
                    }
                    else {
                        itemCount = Number(document.getElementById(IDCount).innerHTML);
                    }
                    typeCount = typeCount + itemCount;

                    if (menuLeftList[j].ParentID.toUpperCase() == livingID) {
                        livingCount = livingCount + itemCount;

                    }
                    if (menuLeftList[j].ParentID.toUpperCase() == diningID) {
                        diningCount = diningCount + itemCount;
                        //var diningIDHTML = diningID + "ItemCount" + region + "Filter";
                        //if (document.getElementById(diningIDHTML)) {
                        //    document.getElementById(diningIDHTML).innerHTML = livingCount;
                        //}
                    }
                    if (menuLeftList[j].ParentID.toUpperCase() == bedID) {
                        bedCount = bedCount + itemCount;
                        //var bedIDHTML = bedID + "ItemCount" + region + "Filter";
                        //if (document.getElementById(bedIDHTML)) {
                        //    document.getElementById(bedIDHTML).innerHTML = livingCount;
                        //}
                    }
                    if (menuLeftList[j].ParentID.toUpperCase() == officeID) {
                        officeCount = officeCount + itemCount;
                        //var officeIDHTML = officeID + "ItemCount" + region + "Filter";
                        //if (document.getElementById(officeIDHTML)) {
                        //    document.getElementById(officeIDHTML).innerHTML = livingCount;
                        //}
                    }
                    if (menuLeftList[j].ParentID.toUpperCase() == lightingID) {
                        lightingCount = lightingCount + itemCount;
                        //var lightingIDHTML = lightingID + "ItemCount" + region + "Filter";
                        //if (document.getElementById(lightingIDHTML)) {
                        //    document.getElementById(lightingIDHTML).innerHTML = livingCount;
                        //}
                    }
                    if (menuLeftList[j].ParentID.toUpperCase() == decorID) {
                        decorCount = decorCount + itemCount;
                        //var decorIDHTML = decorID + "ItemCount" + region + "Filter";
                        //if (document.getElementById(decorIDHTML)) {
                        //    document.getElementById(decorIDHTML).innerHTML = livingCount;
                        //}
                    }
                }
                if (menuLeftList[j].Category == collection) {
                    if (menuLeftList[j].ItemCount > 0) {
                        collectionCount = collectionCount + menuLeftList[j].ItemCount;
                    }
                    else {
                        collectionCount = collectionCount + Number(document.getElementById(IDCount).innerHTML);
                    }
                }
                if (menuLeftList[j].Category == lifeStyle) {
                    if (menuLeftList[j].ItemCount > 0) {
                        lifeStyleCount = lifeStyleCount + menuLeftList[j].ItemCount;
                    }
                    else {
                        lifeStyleCount = lifeStyleCount + Number(document.getElementById(IDCount).innerHTML);
                    }
                }
                if (menuLeftList[j].Category == style) {
                    if (menuLeftList[j].ItemCount > 0) {
                        styleCount = styleCount + menuLeftList[j].ItemCount;
                    }
                    else {
                        styleCount = styleCount + Number(document.getElementById(IDCount).innerHTML);
                    }
                }
                if (menuLeftList[j].Category == shape) {
                    if (menuLeftList[j].ItemCount > 0) {
                        shapeCount = shapeCount + menuLeftList[j].ItemCount;
                    }
                    else {
                        shapeCount = shapeCount + Number(document.getElementById(IDCount).innerHTML);
                    }
                }
                if (menuLeftList[j].Category == extending) {
                    extendingCount = extendingCount + menuLeftList[j].ItemCount;
                }
            }
        }
    }

    var IDHTML = livingID + "Li" + region;
    if (livingCount == 0) {
        document.getElementById(IDHTML).hidden = true;
    }
    else {
        IDHTML = livingID + "ItemCount" + region + "Filter";
        document.getElementById(IDHTML).innerHTML = livingCount;
    }
    IDHTML = diningID + "Li" +  region;
    if (diningCount == 0) {
        document.getElementById(IDHTML).hidden = true;
    }
    else {
        IDHTML = diningID + "ItemCount" + region + "Filter";
        document.getElementById(IDHTML).innerHTML = diningCount;
    }
    IDHTML = bedID + "Li" +  region;
    if (bedCount == 0) {
        document.getElementById(IDHTML).hidden = true;
    }
    else {
        IDHTML = bedID + "ItemCount" + region + "Filter";
        document.getElementById(IDHTML).innerHTML = bedCount;
    }
    IDHTML = officeID + "Li" +  region;
    if (officeCount == 0) {
        document.getElementById(IDHTML).hidden = true;
    }
    else {
        IDHTML = officeID + "ItemCount" + region + "Filter";
        document.getElementById(IDHTML).innerHTML = officeCount;
    }
    IDHTML = lightingID + "Li" +  region;
    if (lightingCount == 0) {
        document.getElementById(IDHTML).hidden = true;
    }
    else {
        IDHTML = lightingID + "ItemCount" + region + "Filter";
        document.getElementById(IDHTML).innerHTML = lightingCount;
    }
    IDHTML = decorID + "Li" +  region;
    if (decorCount == 0) {
        document.getElementById(IDHTML).hidden = true;
    }
    else {
        IDHTML = decorID + "ItemCount" + region + "Filter";
        document.getElementById(IDHTML).innerHTML = decorCount;
    }
    roomCount = livingCount + diningCount + bedCount + officeCount + lightingCount + decorCount;
    var MenuLeftID = "MenuLeftRoom" + region;
    if (roomCount == 0) {
        document.getElementById(MenuLeftID).hidden = true;
    }
    else {
        var region001 = "RoomCount" + region;
        var regionFilter = "RoomCount" + region + "Filter";
        document.getElementById(regionFilter).innerHTML = roomCount;
        document.getElementById(MenuLeftID).hidden = false;
        document.getElementById(regionFilter).hidden = false;
        document.getElementById(region001).hidden = true;
    }
    MenuLeftID = "MenuLeftCollection" + region;
    if (collectionCount == 0) {
        document.getElementById(MenuLeftID).hidden = true;
    }
    else {
        var region001 = "CollectionCount" + region;
        var regionFilter = "CollectionCount" + region + "Filter";
        document.getElementById(regionFilter).innerHTML = collectionCount;
        document.getElementById(MenuLeftID).hidden = false;
        document.getElementById(regionFilter).hidden = false;
        document.getElementById(region001).hidden = true;
    }
    MenuLeftID = "MenuLeftLifeStyle" + region;
    if (lifeStyleCount == 0) {
        document.getElementById(MenuLeftID).hidden = true;
    }
    else {
        var region001 = "LifeStyleCount" + region;
        var regionFilter = "LifeStyleCount" + region + "Filter";
        document.getElementById(regionFilter).innerHTML = lifeStyleCount;
        document.getElementById(MenuLeftID).hidden = false;
        document.getElementById(regionFilter).hidden = false;
        document.getElementById(region001).hidden = true;
    }
    MenuLeftID = "MenuLeftStyle" + region;
    if (styleCount == 0) {
        document.getElementById(MenuLeftID).hidden = true;
    }
    else {
        var region001 = "StyleCount" + region;
        var regionFilter = "StyleCount" + region + "Filter";
        document.getElementById(regionFilter).innerHTML = styleCount;
        document.getElementById(MenuLeftID).hidden = false;
        document.getElementById(regionFilter).hidden = false;
        document.getElementById(region001).hidden = true;
    }
    MenuLeftID = "MenuLeftShape" + region;
    if (shapeCount == 0) {
        document.getElementById(MenuLeftID).hidden = true;

    }
    else {
        var region001 = "ShapeCount" + region;
        var regionFilter = "ShapeCount" + region + "Filter";
        document.getElementById(regionFilter).innerHTML = shapeCount;
        document.getElementById(MenuLeftID).hidden = false;
        document.getElementById(regionFilter).hidden = false;
        document.getElementById(region001).hidden = true;
    }
    MenuLeftID = "MenuLeftExtending" + region;
    if (extendingCount == 0) {
        document.getElementById(MenuLeftID).hidden = true;
    }
    else {
        var region001 = "ExtendingCount" + region;
        var regionFilter = "ExtendingCount" + region + "Filter";
        document.getElementById(regionFilter).innerHTML = extendingCount;
        document.getElementById(MenuLeftID).hidden = false;
        document.getElementById(regionFilter).hidden = false;
        document.getElementById(region001).hidden = true;
    }
}