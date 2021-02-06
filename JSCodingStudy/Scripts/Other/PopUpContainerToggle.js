var HelpContainer = $('#help_container');
var doc = $('html');

function PopUpToggleInit(element, full_doc)
{
    var instance = {
        PopUpElement: element,
        Document: full_doc
    }

    instance.Hide = function () {
        instance.PopUpElement.hide();
    }

    instance.Show = function () {
        instance.PopUpElement.show();
    }

    instance.MoveToCenter = function () {
        var screen_width = instance.Document.width();
        var screen_heigth = instance.Document.height();

        var element_width = instance.PopUpElement.width();
        var element_heigth = instance.PopUpElement.height();

        instance.PopUpElement.css({
            left: ((screen_width / 2) - (element_width / 2)),
            top: ((screen_heigth / 2) - (element_heigth / 2)),
        });
    }

    instance.ShowInCenter = function () {
        instance.Show();
        instance.MoveToCenter();
    }

    return instance;
}