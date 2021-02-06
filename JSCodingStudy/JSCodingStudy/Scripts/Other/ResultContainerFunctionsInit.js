function InitResultContainerFinctions(ResultContainer) {
    var instance = {};

    instance.Hide = ResultContainer.Toggle.Hide;
    instance.Show = ResultContainer.Toggle.ShowInCenter;

    instance.SaveButtonDisable = function (flag) {
        ResultContainer.Buttons.Save.prop("disabled", flag);
    }

    instance.SetMessage = function (text) {
        ResultContainer.MessageElement.html(text);
    }
    instance.SetMessageClass = function (text) {
        ResultContainer.MessageElement.attr('class', text);
    }

    instance.Handle = function (res, text) {
        instance.SetMessage(text);
        if (res == 0) {
            instance.SaveButtonDisable(false);
            instance.SetMessageClass('text-success');
        }
        else {
            instance.SaveButtonDisable(true);
            instance.SetMessageClass('text-danger');
        }
        instance.Show();
    }

    return instance;
}