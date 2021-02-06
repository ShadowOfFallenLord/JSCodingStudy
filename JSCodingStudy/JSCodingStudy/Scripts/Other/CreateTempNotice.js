function CreateTempNotice(container_class, text, text_style, btn_text, btn_style) {
    var content = $('<div>');
    content.html(text);
    content.attr('class', text_style);

    var btn = $('<input type="button">');
    btn.val(btn_text);
    btn.attr('class', btn_style);

    var instance = $('<div>');
    instance.attr('class', container_class);
    instance.append(content);
    instance.append(btn);

    btn.click(function () {
        instance.detach();
    })

    return instance;
}