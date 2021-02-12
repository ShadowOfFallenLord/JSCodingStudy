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

    window.CreatePopUpNotice = function () {
        var builder = window.CreateSpecificationBuilder();

        var result = {
            Elements: {
                Content: undefined,
                CloseButton: undefined,
                Container: undefined,
            },
            Functions: {
                Text: {
                    SetContent: undefined,
                    SetCloseButtonText: undefined,
                },
                Classes: {
                    SetContentClass: undefined,
                    SetCloseButtonClass: undefined,
                    SetContainerClass: undefined,
                },
                Visability: {
                    Hide: undefined,
                    Show: undefined,
                },
                HTML: {
                    SetInCenter: undefined,
                    AppendTo: undefined,
                }
            }
        };

        // --- Elements ---
        result.Elements.Content = builder.Clear().SetTag('div').Parse();

        result.Elements.CloseButton = builder.Clear().SetTag('input')
            .SetAttrebute('type', 'button').Parse();

        result.Elements.Container = builder.Clear().SetTag('div')
            .AddInnerHtml(result.Elements.Content)
            .AddInnerHtml(result.Elements.CloseButton)
            .Parse()
        // -- End Elements ---
        // -- Events ---
        result.Elements.CloseButton.click(function () {
            result.Elements.Container.detach();
        })
        // --- End Events ---
        // --- Functions Text ---
        result.Functions.Text.SetContent = function (text) {
            result.Elements.Content.html(text);
            return result;
        };

        result.Functions.Text.SetCloseButtonText = function (text) {
            result.Elements.CloseButton.val(text);
            return result;
        };
        // --- End Functions Text ---
        // --- Functions Styles ---
        result.Functions.Classes.SetContentClass = function (text) {
            result.Elements.Content.attr('class', text);
            return result;
        };

        result.Functions.Classes.SetCloseButtonClass = function (text) {
            result.Elements.CloseButton.attr('class', text);
            return result;
        };

        result.Functions.Classes.SetContainerClass = function (text) {
            result.Elements.Container.attr('class', text);
            return result;
        };
        // --- End Functions Styles ---
        // --- Functions Visability ---
        result.Functions.Visability.Hide = function () {
            result.Elements.Container.Hide();
            return result;
        };

        result.Functions.Visability.Show = function () {
            result.Elements.Container.Show();
            return result;
        };
        // --- End Functions Visability ---
        // --- Functions HTML ---
        result.Functions.HTML.SetInCenter = function (element) {
            var screen_width = element.width();
            var screen_heigth = element.height();

            var container_width = result.Elements.Container.width();
            var container_heigth = result.Elements.Container.height();

            result.Elements.Container.css({
                left: ((screen_width / 2) - (container_width / 2)),
                top: ((screen_heigth / 2) - (container_heigth / 2)),
            });
            return result;
        };

        result.Functions.HTML.AppendTo = function (parent) {
            parent.append(result.Elements.Container);
            return result;
        };
        // --- End Functions HTML ---

        return result;
    }
})();