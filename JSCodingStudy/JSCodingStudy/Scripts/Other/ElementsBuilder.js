(function () {
    window.CreateJQueryBySpecification = function (spec) {
        var result = $('<' + spec.Tag + '>');

        if (spec.Text !== undefined) {
            result.text(spec.Text);
        }

        if (spec.Value !== undefined) {
            result.val(spec.Value);
        }

        for (var i in spec.InnerElements) {
            var cur = spec.InnerElements[i];
            if (cur.specification) {
                cur = window.CreateJQueryBySpecification(cur.content);
            }
            else {
                cur = cur.content;
            }
            result.append(cur);
        }

        for (var key in spec.Attrebutes) {
            result.attr(key, spec.Attrebutes[key]);
        }

        for (var key in spec.Events) {
            result.on(key, spec.Events[key](result));
        }

        return result;
    }

    window.CreateSpecificationBuilder = function () {
        var result = {};

        var instance = {};

        instance.Clear = function () {
            result = {
                Tag: undefined,
                Text: undefined,
                Value: undefined,
                InnerElements: [],
                Attrebutes: {},
                Events: {}
            };

            result.Copy = function () {
                var temp = {
                    Tag: this.Tag,
                    Text: this.Text,
                    Value: this.Value,
                    InnerElements: [],
                    Attrebutes: {},
                    Events: {}
                }

                for (var i in this.InnerElements) {
                    var cur = spec.InnerElements[i];
                    if (cur.specification) {
                        cur = cur.Copy();
                    }
                    temp.InnerElements.push(cur);
                }

                for (var key in this.Attrebutes) {
                    temp.Attrebutes[key] = this.Attrebutes[key];
                }

                for (var key in this.Events) {
                    temp.Events[key] = this.Events[key](result);
                }

                return temp;
            }

            return instance;
        }

        instance.SetTag = function (text) {
            result.Tag = text;
            return instance;
        }

        instance.SetAttrebute = function (attr, content) {
            result.Attrebutes[attr] = content;
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

        instance.AddInnerHtml = function (html) {
            result.InnerElements.push({
                specification: false,
                content: html
            });
            return instance;
        }

        instance.AddInnerSpecification = function (spec) {
            result.InnerElements.push({
                specification: true,
                content: spec
            });
            return instance;
        }

        instance.SetEvent = function (e, handler_creator) {
            result.Events[e] = handler_creator;
            return instance;
        }

        instance.GetResult = function () {
            return result.Copy();
        }

        instance.Parse = function () {
            return window.CreateJQueryBySpecification(result);
        }

        return instance.Clear();
    }
})();