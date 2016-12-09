var _url, _menuString;

function BindMenu(url) {
    callwebservice(url, '', '', '', BindMenuComplete, false, true, datatypeEnum.json);
}

function BindMenuComplete(data) {
    if (data != null && data != "") {
        _menuString = "<div id='sidebar-collapse' class='visible-lg'><i class='fa fa-angle-double-left'></i></div><ul class='nav nav-list'><li>"
                    + "<form target='#' method='GET' class='search-form'>"
                        + "<span class='search-pan'></span></form></li>";
        var childMenuString = "";
        var haveChildern;
        var menu = eval(data);

        for (var i = 0; i < menu.length; i++) {
            if (menu[i][7] == "") {
                haveChildern = false;
                if (menu[i][1] == "" || menu[i][0] == "")
                    _menuString += "<li><a class='dropdown-toggle' href='#'>" +
                        "<i class='" + menu[i][2] + "'></i><span>" + menu[i][3] + " </span><b class='arrow fa fa-angle-right'></b></a>";
                else
                    _menuString += "<li><a id=" + menu[i][1] + " href=" + menu[i][5] + "/" + menu[i][1] + "/" + menu[i][0] + ">" +
                        "  <i class='" + menu[i][2] + "'></i><span>" + menu[i][3] + "</span></a>";


                for (var k = 0; k < menu.length; k++) {
                    if (menu[k][7] == menu[i][6]) {
                        haveChildern = true;
                        childMenuString += "<li><a id=" + menu[k][1] + " href=" + menu[k][5] + "/" + menu[k][1] + "/" + menu[k][0] + " >" + menu[k][3] + "</a></li>";
                    }
                }

                if (haveChildern) {
                    _menuString += "<ul class='submenu'>";
                    _menuString += childMenuString;
                    _menuString += "</ul>";
                    childMenuString = "";
                }

                _menuString += "</li>";
            }
        }

        _menuString += "</ul>";

        $("#sidebar").html(_menuString);

        handleUserLayoutSetting();

    } else {
        $("#sidebar").html("");
    }

}

var scrollableSidebar = function () {
    if ($('#sidebar.sidebar-fixed').size() == 0) {
        $('#sidebar .nav').css('height', 'auto');
        return;
    }
    if ($('#sidebar.sidebar-fixed.sidebar-collapsed').size() > 0) {
        $('#sidebar .nav').css('height', 'auto');
        return;
    }
    var winHeight = $(window).height() - 90;
    $('#sidebar.sidebar-fixed .nav').slimScroll({ height: winHeight + 'px', position: 'left' });
};

function setActiveMenulink() {

    var url = window.location.pathname.split("/");

    var questions = url[1];

    $('ul.nav-list li ').removeClass('active');

    $('ul.nav-list li:has(a[id="' + questions + '"])').addClass('active').closest('.submenu').addClass('active');
}

function handleUserLayoutSetting() {
    if (typeof cookie_not_handle_user_settings != 'undefined' && cookie_not_handle_user_settings == true) {
        return;
    }
    //Collapsed sidebar
    if ($.cookie('sidebar-collapsed') == 'true') {
        $('#sidebar').addClass('sidebar-collapsed');
    }

    //Fixed sidebar
    if ($.cookie('sidebar-fixed') == 'true') {
        $('#sidebar').addClass('sidebar-fixed');
    }

    $('#sidebar.sidebar-collapsed #sidebar-collapse > i').attr('class', 'fa fa-angle-double-right');
    $('#sidebar-collapse').click(function () {
        $('#sidebar').toggleClass('sidebar-collapsed');
        if ($('#sidebar').hasClass('sidebar-collapsed')) {
            $('#sidebar-collapse > i').attr('class', 'fa fa-angle-double-right');
            $.cookie('sidebar-collapsed', 'true');
            $("#sidebar ul.nav-list").parent('.slimScrollDiv').replaceWith($("#sidebar ul.nav-list"));
        } else {
            $('#sidebar-collapse > i').attr('class', 'fa fa-angle-double-left');
            $.cookie('sidebar-collapsed', 'false');
            scrollableSidebar();
        }
    });

    $('#sidebar a.dropdown-toggle').click(function () {
        var submenu = $(this).next('.submenu');
        var arrow = $(this).children('.arrow');
        if (arrow.hasClass('fa-angle-right')) {
            arrow.addClass('anim-turn90');
        }
        else {
            arrow.addClass('anim-turn-90');
        }
        submenu.slideToggle(400, function () {
            if ($(this).is(":hidden")) {
                arrow.attr('class', 'arrow fa fa-angle-right');
            } else {
                arrow.attr('class', 'arrow fa fa-angle-down');
            }
            arrow.removeClass('anim-turn90').removeClass('anim-turn-90');
        });
    });

    $('#sidebar').on('show.bs.collapse', function () {
        if ($(this).hasClass('sidebar-collapsed')) {
            $(this).removeClass('sidebar-collapsed');
        }
    });

    $('#sidebar').on('show.bs.collapse', function () {
        $("html, body").animate({ scrollTop: 0 }, 100);
    });

    setActiveMenulink();
}