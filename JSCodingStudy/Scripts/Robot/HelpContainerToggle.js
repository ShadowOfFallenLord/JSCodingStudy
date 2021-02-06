var HelpContainer = $('#help_container');
var doc = $('html');

$('#close_help_button').click(function () {
    HelpContainer.hide();
});

html_elements.Buttons.HelpButton.click(function () {
    HelpContainer.show();

    var screen_width = doc.width();
    var screen_heigth = doc.height();

    var element_width = HelpContainer.width();
    var element_heigth = HelpContainer.height();

    HelpContainer.css({
        left: ((screen_width / 2) - (element_width / 2)),
        top: ((screen_heigth / 2) - (element_heigth / 2)),
    });
});