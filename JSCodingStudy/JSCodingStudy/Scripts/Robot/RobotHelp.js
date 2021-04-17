export function GetHelpAPI() {

    function parse_to_li(help_object) {
        var main_html = document.createElement('li');
        main_html.innerHTML = help_object.Code + ' - ' + help_object.Desctiption;
        main_html.append(document.createElement('br'));
        main_html.innerHTML += 'Аргументы:';
        if (help_object.Arguments == null || help_object.Arguments.length < 1) {
            main_html.innerHTML += 'Нет';
        } else {
            main_html.append(document.createElement('br'));

            var args = document.createElement('ul');

            for (var i in help_object.Arguments) {
                var current_argument = help_object.Arguments[i];
                var arg_html = document.createElement('li');
                arg_html.innerHTML = current_argument.Name + ' - ' + current_argument.Desctiption;
                arg_html.append(document.createElement('br'));

                var agr_variants_html = document.createElement('ul');

                for (var vi in current_argument.Variants) {
                    var current_var = current_argument.Variants[vi];
                    var c_v_html = document.createElement('li');
                    c_v_html.innerHTML = current_var.Code + ' - ' + current_var.Desctiption;
                    agr_variants_html.append(c_v_html);
                }

                arg_html.append(agr_variants_html);
                args.append(arg_html);
            }

            main_html.append(args);
        }


        return main_html;
    }

    var instance = {
        GetHelp: function (move, check, draw) {
            var res = [];

            if (move) {
                res.push({
                    /**
                     * Код функции
                     */
                    Code: 'Robot.Move(<Направление>)',
                    /**
                     * Описание функции
                     */
                    Desctiption: 'Передвинуть робота в выбранном направлении',
                    /**
                     * Аргументы функции
                     */
                    Arguments: [
                        /**
                         * Аргумент
                         */
                        {
                            /**
                             * Имя аргумента
                             */
                            Name: '<Направление>',
                            /**
                             * Описание аргумента
                             */
                            Desctiption: 'Направление, в котором робот будет передвинут',
                            /**
                             * Варианты
                             */
                            Variants: [
                                /**
                                 * Код варианта
                                 */
                                {
                                    Code: 'Directions.Up',
                                    /**
                                     * Описание варианта
                                     */
                                    Desctiption: 'Вверх'
                                },
                                /**
                                 * Код варианта
                                 */
                                {
                                    Code: 'Directions.Down',
                                    /**
                                     * Описание варианта
                                     */
                                    Desctiption: 'Вниз'
                                },
                                /**
                                 * Код варианта
                                 */
                                {
                                    Code: 'Directions.Left',
                                    /**
                                     * Описание варианта
                                     */
                                    Desctiption: 'Влево'
                                },
                                /**
                                 * Код варианта
                                 */
                                {
                                    Code: 'Directions.Right',
                                    /**
                                     * Описание варианта
                                     */
                                    Desctiption: 'Вправо'
                                },
                            ]
                        }
                    ]
                })
            }

            if (check) {
                res.push({
                    /**
                     * Код функции
                     */
                    Code: 'Robot.Check(<Направление>, <Проверка>)',
                    /**
                     * Описание функции
                     */
                    Desctiption: 'Проверить, выполняется ли заданное условие для выбранной клетки',
                    /**
                     * Аргументы функции
                     */
                    Arguments: [
                        /**
                         * Аргумент
                         */
                        {
                            /**
                             * Имя аргумента
                             */
                            Name: '<Направление>',
                            /**
                             * Описание аргумента
                             */
                            Desctiption: 'Направление, в котором робот будет передвинут',
                            /**
                             * Варианты
                             */
                            Variants: [
                                /**
                                 * Код варианта
                                 */
                                {
                                    Code: 'Directions.Up',
                                    /**
                                     * Описание варианта
                                     */
                                    Desctiption: 'Вверх'
                                },
                                /**
                                 * Код варианта
                                 */
                                {
                                    Code: 'Directions.Down',
                                    /**
                                     * Описание варианта
                                     */
                                    Desctiption: 'Вниз'
                                },
                                /**
                                 * Код варианта
                                 */
                                {
                                    Code: 'Directions.Left',
                                    /**
                                     * Описание варианта
                                     */
                                    Desctiption: 'Влево'
                                },
                                /**
                                 * Код варианта
                                 */
                                {
                                    Code: 'Directions.Right',
                                    /**
                                     * Описание варианта
                                     */
                                    Desctiption: 'Вправо'
                                },
                            ]
                        },

                        /**
                         * Аргумент
                         */
                        {
                            /**
                             * Имя аргумента
                             */
                            Name: '<Проверка>',
                            /**
                             * Описание аргумента
                             */
                            Desctiption: 'Условие для клетки',
                            /**
                             * Варианты
                             */
                            Variants: [
                                /**
                                 * Код варианта
                                 */
                                {
                                    Code: 'Checks.Void',
                                    /**
                                     * Описание варианта
                                     */
                                    Desctiption: 'Клетка пуста'
                                },
                                /**
                                 * Код варианта
                                 */
                                {
                                    Code: 'Checks.Wall',
                                    /**
                                     * Описание варианта
                                     */
                                    Desctiption: 'Клетка является стеной'
                                },
                                /**
                                 * Код варианта
                                 */
                                {
                                    Code: 'Checks.Clear',
                                    /**
                                     * Описание варианта
                                     */
                                    Desctiption: 'Клетка не закрашена'
                                },
                                /**
                                 * Код варианта
                                 */
                                {
                                    Code: 'Checks.Filled',
                                    /**
                                     * Описание варианта
                                     */
                                    Desctiption: 'Клетка закрашена'
                                },
                            ]
                        }
                    ]
                })
            }

            if (draw) {
                res.push({
                    /**
                     * Код функции
                     */
                    Code: 'Robot.Draw()',
                    /**
                     * Описание функции
                     */
                    Desctiption: 'Закрасить клетку, в которой стоит робот',
                    /**
                     * Аргументы функции
                     */
                    Arguments: []
                })
            }

            return res;
        },
        ParseHelpObjectToHTML_li: parse_to_li,
        ParseHelp: function (help_array) {
            var main_html = document.createElement('ul');
            for (var i in help_array) {
                main_html.append(parse_to_li(help_array[i]));
            }
            return main_html;
        }
    }

    return instance;
}