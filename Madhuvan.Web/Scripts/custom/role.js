function CheckAll(chkItem, chkHeader) {


    if ($('.grid ' + chkItem.selector).length != 0 && $('.grid ' + chkItem.selector).length == $('.grid ' + chkItem.selector + ':Checked').length) {
        $(chkHeader).attr("checked", true);
    } else {
        $(chkHeader).attr("checked", false);
    }
}


function getRowId(value) {
    var mychar;
    var abc = 0;
    for (var i = 1; i < 4; i++) {
        mychar = value.substring(i, i - 1);
        if (value.indexOf(mychar) == -1) {
            return false;
        } else {
            abc++;
        }
    }

    return value.substring(abc + 1);
}

function Check(chkItem, chkHeader) {

    var childId = 0;
    debugger;
    if ($(chkItem).is(':checked')) {
        if (chkItem.className.indexOf("View") < 0) {
            $(chkItem).parent().siblings().eq(1).children()[0].checked = true;
        }
        childId = $(chkItem).parentsUntil('.headerrow').parent().attr('id');

        checkforHeaderElement(childId);
       // rowId = getRowId(childId);
       // $('tr[id=' + rowId + ']').children().find("[class^=View]").attr('checked', 'true');

    }
    else {
        if (chkItem.className.indexOf("View") >= 0) {
            $(chkItem).parent().parent().find("input[type='checkbox']").removeAttr('checked');
        }

        childId = $(chkItem).parentsUntil('.headerrow').parent().attr('id');
        checkforHeaderElement(childId);

       // debugger;
        // parentrowId = getRowId(childId);
        // alert(parentrowId);
        // if ($('tr[id=' + parentrowId + ']').is(':checked')) {
             
        //} else {
        //     $('tr[id=' + parentrowId + ']').children().find("input[type=checkbox]").prop('checked', false);
        //}
    }
}


function checkforHeaderElement(headermenuId) {

    var rowId = 0;
    var currentid = '#' + headermenuId;

    
    $(currentid).children().find("table").find("tr").find("input[type=checkbox]").each(function () {

        var countCheckedId = $(currentid).children().find("table").find("tr").find("input:checked").length;
        //var isparentMenu = 
        rowId = getRowId(headermenuId);
        
        if (countCheckedId > 0) {
            $('tr[id=' + rowId + ']').children().find("[class^=View]").prop('checked', true);

        } else {
            $('tr[id=' + rowId + ']').children().find("[class^=View]").prop('checked', false);
        }
    });
}

function getInputValue(element) {
    return $(element).val();
}

function setInputValueById(id, value) {
    return $("#" + id).val(value);
}

function setAttributeByClass(className, attribute, value) {
    $("." + className).attr(attribute, value);
}

function getAttributeById(id, attribute) {
    return $("#" + id).attr(attribute);
}

function setAttributeById(id, attribute, value) {
    $("#" + id).attr(attribute, value);
}

function setAttribute(element, attribute, value) {
    $(element).attr(attribute, value);
}

function removeAttribute(element, attribute) {
    $(element).removeAttr(attribute);
}

function CheckHeader(chkHeader, chkItem) {

    debugger;

    if ($(chkHeader).is(':checked')) {
        switch (chkItem) {
            case "View":
                setAttribute('input:checkbox[ class ^= "View"]', "checked", "checked");
                break;
            case "Add":
                setAttribute('input:checkbox[ class ^= "Add"]', "checked", "checked");
                setAttribute($('input:checkbox[ class ^= "Add"]').parent().siblings().find('input:checkbox[ class ^= "View"]'), "checked", "checked");
                break;
            case "Edit":
                setAttribute('input:checkbox[ class ^= "Edit"]', "checked", "checked");
                setAttribute($('input:checkbox[ class ^= "Edit"]').parent().siblings().find('input:checkbox[ class ^= "View"]'), "checked", "checked");
                break;
            case "Delete":
                setAttribute('input:checkbox[ class ^= "Delete"]', "checked", "checked");
                setAttribute($('input:checkbox[ class ^= "Delete"]').parent().siblings().find('input:checkbox[ class ^= "View"]'), "checked", "checked");
                break;
            case "Report":
                setAttribute('input:checkbox[ class ^= "Report"]', "checked", "checked");
                setAttribute($('input:checkbox[ class ^= "Report"]').parent().siblings().find('input:checkbox[ class ^= "View"]'), "checked", "checked");
                break;
            case "Assign":
                setAttribute('input:checkbox[ class ^= "Assign"]', "checked", "checked");
                setAttribute($('input:checkbox[ class ^= "Assign"]').parent().siblings().find('input:checkbox[ class ^= "View"]'), "checked", "checked");
                break;
            default:
        }
    } else {
        switch (chkItem) {
            case "View":
                removeAttribute('input:checkbox[ class ^= "View"]', 'checked');
                removeAttribute('input:checkbox[ class ^= "Add"]', "checked");
                removeAttribute('input:checkbox[ class ^= "Edit"]', "checked");
                removeAttribute('input:checkbox[ class ^= "Delete"]', "checked");
                removeAttribute('input:checkbox[ class ^= "Report"]', "checked");
                removeAttribute('input:checkbox[ class ^= "Assign"]', "checked");
                break;
            case "Add":
                removeAttribute('input:checkbox[ class ^= "Add"]', "checked");
                break;
            case "Edit":
                removeAttribute('input:checkbox[ class ^= "Edit"]', "checked");
                break;
            case "Delete":
                removeAttribute('input:checkbox[ class ^= "Delete"]', "checked");
                break;
            case "Report":
                removeAttribute('input:checkbox[ class ^= "Report"]', "checked");
                break;
            case "Assign":
                removeAttribute('input:checkbox[ class ^= "Assign"]', "checked");
                break;
            default:
        }
    }
    checkAllHeader();
}

function checkAllHeader() {
    setAttributeByClass("chkInnerHeaderView", "checked", $('.grid .View').length != 0 && $('.grid .View').length == $('.grid .View:Checked').length ? true : false);
    setAttributeByClass("chkInnerHeaderAdd", "checked", $('.grid .Add').length != 0 && $('.grid .Add').length == $('.grid .Add:Checked').length ? true : false);
    setAttributeByClass("chkInnerHeaderEdit", "checked", $('.grid .Edit').length != 0 && $('.grid .Edit').length == $('.grid .Edit:Checked').length ? true : false);
    setAttributeByClass("chkInnerHeaderDelete", "checked", $('.grid .Delete').length != 0 && $('.grid .Delete').length == $('.grid .Delete:Checked').length ? true : false);
    setAttributeByClass("chkInnerHeaderReport", "checked", $('.grid .Report').length != 0 && $('.grid .Report').length == $('.grid .Report:Checked').length ? true : false);
    setAttributeByClass("chkInnerHeaderAssign", "checked", $('.grid .Assign').length != 0 && $('.grid .Assign').length == $('.grid .Assign:Checked').length ? true : false);
}

function CheckInnerHeader(control, chkClass) {
    var selector = $('input:checkbox[class ^= "' + getAttribute(control, "Class") + '"][class *= "' + getAttribute(control, "Class").split("_")[1] + '" ]');
    var isControlChecked = $(control).is(':checked');

    $(selector).each(function (i, el) {
        var elClass = new Array();
        elClass = getAttribute(el, "class").split('_');
        if (elClass.length > 2) {
            var thirdLevelClass = elClass[0] + "_" + elClass[2];
            $("." + thirdLevelClass).each(function (j, ele) {
                if (isControlChecked) {
                    if (elClass[0] != "View")
                        setAttribute($(ele).parent().siblings().eq(1).children(), 'checked', 'checked');
                    setAttribute(ele, 'checked', 'checked');
                }
                else {
                    if (elClass[0] == "View")
                        removeAttribute($(ele).parent().parent().find("input[type='checkbox']"), 'checked');
                    else
                        removeAttribute(ele, 'checked');
                }
            });
        }
        if (isControlChecked) {
            if (elClass[0] != "View")
                setAttribute($(el).parent().siblings().eq(1).children(), 'checked', 'checked');
            setAttribute(el, 'checked', 'checked');
        }
        else {
            if (elClass[0] == "View")
                removeAttribute($(el).parent().parent().find("input[type='checkbox']"), 'checked');
            else
                removeAttribute(el, 'checked');
        }
    });
}

function CheckAllInnerHeader(chkHeader, chkClass, menuId) {
    if (chkClass != 'View') {
        if ($(chkHeader).is(':checked')) {
            setAttributeByClass("chkHeaderView" + menuId, "checked", "checked");
            setAttributeById(menuId + " input[type='checkbox'].View", "checked", "checked");
        }
        else
            removeAttributeByClass("chkHeaderView" + menuId, "checked");
    }
}

function removeAttributeByClass(className, attribute) {
    $("." + className).removeAttr(attribute);
}

function showhidetable(object, menuId) {
    if ($(object).hasClass('k-i-expand'))
        $(object).removeClass('k-i-expand').addClass('k-i-collapse');
    else
        $(object).removeClass('k-i-collapse').addClass('k-i-expand');

    $('#' + menuId).toggle();




}


