import * as FieldConstants from './Field/FieldConstans.js'
import * as FieldAPI from './Field/FieldAPI.js'
import * as RobotConstants from './Robot/RobotConstants.js'
import * as RobotAPI from './Robot/RobotAPI.js'
import * as CommonAPI from './Common/Common.js'
import * as RobotControlerAPI from './RobotControler.js'

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
        GetHelp: function(move, check, draw) {
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
                    Desctiption: 'Закрасить клетку, в которйо стоит робот',
                    /**
                     * Аргументы функции
                     */
                    Arguments: []
                })
            }

            return res;
        },
        ParseHelpObjectToHTML_li: parse_to_li,
        ParseHelp: function(help_array) {
            var main_html = document.createElement('ul');
            for (var i in help_array) {
                main_html.append(parse_to_li(help_array[i]));
            }
            return main_html;
        }
    }

    return instance;
}

/**
 * Создание API для робота.
 *
 * @param {Number} width Ширина поля в клетках.
 * @param {Number} height Высота поля в клетках.
 * @param {Boolean} manual_cells_installation Можно ли вручную устанавливать стены, кликая по 
 * @param {Number} start_pos_x Стартовая позиция робота по X.
 * @param {Number} start_pos_y Стартовая позиция робота по Y.
 * @param {HTMLElement} html_loger Элемент логера.
 * @param {Number} queue_delay Задержка.
 */
export function CreateFullRobotAPI(width, height, manual_cells_installation, start_pos_x, start_pos_y, html_loger, queue_delay) {

    var field = FieldAPI.CreateGameField(width, height, manual_cells_installation);
    var robot_controler = RobotControlerAPI.CreateRobotControler(start_pos_x, start_pos_y, field);
    robot_controler.ReDrawField();
    var loger = CommonAPI.CreateLoger(html_loger);
    var queue = CommonAPI.CreateExecutionQueue(queue_delay);

    var queue_controler = {
        /**
         * Перемещение робота на 1 клетку
         * @param {RobotConstants.Direction} direction Направление
         */
        Move: function(direction) {
            if (robot_controler.Robot.Destroed) return;

            robot_controler.Move(direction);
            robot_controler.ReDrawField();

            queue.Add(function() {
                robot_controler.Move(direction);
                robot_controler.ReDrawField();
                loger.Add('Передвинуться ' + direction.Text);
                if (robot_controler.Robot.Destroed) {
                    loger.Add('Уничтожен');
                }
            })
        },

        /**
         * Проверить клетку 
         * @param {RobotConstants.Direction} direction Направление
         * @param {RobotConstants.CheckVariant} variant Что проверяем 
         */
        Check: function(direction, variant) {
            if (robot_controler.Robot.Destroed) return;

            var flag = robot_controler.Check(direction, variant);

            queue.Add(function() {
                loger.Add('Проверить ' + direction.Text + ' ' + variant.Text + ':' + (flag ? '+' : '-'));
            })

            return flag;
        },

        /**
         * Закрасить клетку
         */
        Draw: function() {
            if (robot_controler.Robot.Destroed) return;

            robot_controler.Draw();

            queue.Add(function() {
                robot_controler.Draw();
                loger.Add('Закрасить');
            })
        },
    }

    function reset_robot_state() {
        robot_controler.Robot.Destroed = false;
        robot_controler.Robot.X = start_pos_x;
        robot_controler.Robot.Y = start_pos_y;
        robot_controler.ReDrawField();
        field.Clear();
        loger.Clear();
    }

    function check_correct_execute() {
        if (robot_controler.Robot.Destroed) {
            return 'Неудача. Робот был уничтожен.';
        }

        if (field.HasFinish) {
            var cell = field.Rows[robot_controler.Robot.Y].Columns[robot_controler.Robot.X]
            if (cell.Content != FieldConstants.CellContents.Finish) {
                return 'Неудача. Робот закончил свое передвижение не на финише.';
            }
        }

        for(var i in field.FlagsElements)
        {
            if(field.FlagsElements[i].Content != FieldConstants.CellContents.UsedFlag)
            {
                return 'Неудача. Робот посетил не все обязательные точки.';
            }
        }

        return 'Удачно!';
    }

    var instance = {
        Field: field,
        Reset: reset_robot_state,
        Execute: function(code) {
            try {
                reset_robot_state();
                var f = new Function('Robot', 'Directions', 'Checks', code);
                f(queue_controler, RobotConstants.Directions, RobotConstants.CheckVariants);
                queue.Add(() => alert(check_correct_execute()));
                reset_robot_state();
                queue.Execute();
                queue.Clear();
            } catch {
                alert('Некорректный код!')
            }
        },
    };

    return instance;
}