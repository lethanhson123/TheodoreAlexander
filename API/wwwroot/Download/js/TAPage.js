
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
    var url = "https://api.theodorealexander.com/api/Common/SubcribeEmail";
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
function onInitializationPage() {   
    onInitializationUser();
    var region = window.localStorage.getItem('Region');    
    if (region) {
        if (region.length > 0) {
            if (region == 'TAUS') {                
                onViewUS();
            }
            else {
                onViewInternational();
            }
        }
        else {
            onCheckUS();
        }
    }
    else {
        onCheckUS();
    }
}
function onCheckUS() {
    var url = "https://api.ipregistry.co/?key=tryout";
    $.ajax({
        url: url,
        type: 'GET',
        success: function (data) {
            var region = data["location"]["country"]["code"];
            if (region == 'US') {
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
    document.getElementById("MenuTopBrandTAStudioInternational").hidden = true;    
    document.getElementById("TAStudioFrenzyUSMobile").hidden = true;
    document.getElementById("TAStudioHolliUSMobile").hidden = true;

    document.getElementById("MenuBrandTAAccentsSub").hidden = false;    
    document.getElementById("LaurentUS").hidden = false;
    document.getElementById("MenuBrandSALONEImageUS").hidden = false;    
    document.getElementById("MenuBrandTAStudioImageUS").hidden = false;
    document.getElementById("MenuBrandTAAccentsImageUS").hidden = false;
    document.getElementById("MenuTopBrandTAStudioUS").hidden = false;
}
function onViewInternational() {
    window.localStorage.setItem('Region', 'International');
    document.getElementById("MenuBrandSALONESub").hidden = false;
    document.getElementById("MenuBrandSALONEMobile").hidden = false;
    document.getElementById("LaurentInternational").hidden = false;
    document.getElementById("MenuBrandSALONEImageInternational").hidden = false;
    document.getElementById("MenuBrandTAStudioImageInternational").hidden = false;
    document.getElementById("MenuBrandTAAccentsImageInternational").hidden = false;
    document.getElementById("MenuTopBrandTAStudioInternational").hidden = false;
    document.getElementById("TAStudioFrenzyUSMobile").hidden = false;
    document.getElementById("TAStudioHolliUSMobile").hidden = false;

    document.getElementById("MenuBrandTAAccentsSub").hidden = true;    
    document.getElementById("LaurentUS").hidden = true;
    document.getElementById("MenuBrandSALONEImageUS").hidden = true;    
    document.getElementById("MenuBrandTAStudioImageUS").hidden = true;
    document.getElementById("MenuBrandTAAccentsImageUS").hidden = true;
    document.getElementById("MenuTopBrandTAStudioUS").hidden = true;
}
function onInitializationUser() {
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
        window.location.href = 'https://theodorealexander.com/product-listing;OrderBy=IsNew;requestCount=1;SearchKey=' + value;
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
            window.location.href = 'https://theodorealexander.com/product-listing;OrderBy=IsNew;requestCount=1;SearchKey=' + ele.value;
        }
    }
}
function onHeaderSearchInputMobileEnter(ele) {
    if (event.key === 'Enter') {
        if (ele.value) {
            window.location.href = 'https://theodorealexander.com/product-listing;OrderBy=IsNew;requestCount=1;SearchKey=' + ele.value;
        }
    }
}
function onHeaderSearchInputMobile() {
    var value = document.getElementById('HeaderSearchInputMobile').value;
    if (value) {
        window.location.href = 'https://theodorealexander.com/product-listing;OrderBy=IsNew;requestCount=1;SearchKey=' + value;
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

    var menuLIGHTINGMobileHidden = document.getElementById("MenuLIGHTINGMobile").hidden;
    if (menuLIGHTINGMobileHidden) {
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
function onOpenSubjectList() {
    var hidden = document.getElementById("SubjectList").hidden;
    hidden = !hidden;
    document.getElementById("SubjectList").hidden = hidden;
}
function onSubjectSelected(name) {
    document.getElementById("SubjectList").hidden = true;
    document.getElementById("SubjectSelectedName").innerHTML = name;
}
function onContactSendEmail() {
    document.getElementById("Note").innerHTML = "CONTACT US: Send email success.";
    var subject = document.getElementById("SubjectSelectedName").innerHTML;
    var email = document.getElementById("ContactEmail").value;
    var phone = document.getElementById("ContactPhone").value;
    var message = document.getElementById("ContactComment").value;
    var url = "https://api.theodorealexander.com/api/Common/ContactEmail";
    var data = {
        Subject: subject,
        Email: email,
        Phone: phone,
        Message: message
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