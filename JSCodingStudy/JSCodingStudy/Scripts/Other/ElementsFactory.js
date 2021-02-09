(function () {
    window.CreateJQueryBySpecification = function (spec) {
        var result = $('<' + spec.Tag + '>');

        if (spec.Text !== undefined) {
            result.text(spec.Text);
        }

        if (spec.Value !== undefined) {
            result.val(spec.Value);
        }

        if (spec.InnerHtml !== undefined) {
            result.html(spec.InnerHtml);
        }

        for (var key in spec.Attrebuts) {
            result.attr(key, spec.Attrebuts[key]);
        }

        for (var key in spec.Events) {
            result.on(key, spec.Events[key](result));
        }

        return result;
    }

    window.CreateSpecificationBuilder = function () {
        var result = {
            Tag: undefined,
            Text: undefined,
            Value: undefined,
            InnerHtml: undefined,
            Attrebuts: {},
            Events: {}
        };

        var instance = {};

        instance.GetResult = function () {
            return result;
        }

        instance.Clear = function () {
            result = {
                Tag: undefined,
                Text: undefined,
                Value: undefined,
                InnerHtml: undefined,
                Attrebuts: {},
                Events: {}
            };
            return instance;
        }

        instance.SetTag = function (text) {
            result.Tag = text;
            return instance;
        }

        instance.SetAttrebut = function (attr, content) {
            result.Attrebuts[attr] = content;
            return instance;
        }

        instance.SetText = function (text) {
            result.Text = text;
            return instance;
        }

        instance.SetValue = function (val) {
            result.Value = val;
            return instance;
        }

        instance.SetInnerHtml = function (html) {
            result.InnerHtml = html;
            return instance;
        }

        instance.SetEvent = function (e, handler_creator)
        {
            result.Events[e] = handler_creator;
            return instance;
        }

        instance.Parse = function () {
            return window.CreateJQueryBySpecification(result);
        }

        return instance;
    }
})();