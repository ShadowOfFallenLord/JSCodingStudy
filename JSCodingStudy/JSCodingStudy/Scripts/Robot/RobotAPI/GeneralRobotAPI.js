import * as FieldConstants from './Field/FieldConstans.js'
import * as FieldAPI from './Field/FieldAPI.js'
import * as RobotConstants from './Robot/RobotConstants.js'
import * as RobotAPI from './Robot/RobotAPI.js'
import * as CommonAPI from './Common/Common.js'
import * as RobotControlerAPI from './RobotControler.js'

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

    function check_execute_result() {
        if (robot_controler.Robot.Destroed) {
            return 1;
        }

        if (field.HasFinish) {
            var cell = field.Rows[robot_controler.Robot.Y].Columns[robot_controler.Robot.X]
            if (cell.Content != FieldConstants.CellContents.Finish) {
                return 2;
            }
        }

        for (var i in field.FlagsElements) {
            if (field.FlagsElements[i].Content != FieldConstants.CellContents.UsedFlag) {
                return 3;
            }
        }

        return 0;
    }

    function get_check_correct_execute_string(res) {

        switch (res) {
            case 0: return 'Удачно!';
            case 1: return 'Неудача. Робот был уничтожен.';
            case 2: return 'Неудача. Робот закончил свое передвижение не на финише.';
            case 3: return 'Неудача. Робот посетил не все обязательные точки.';
        }
        return 'Error!';
    }

    function check_correct_execute() {
        var res_int = check_execute_result();
        var res_str = get_check_correct_execute_string(res_int);
        alert(res_str);
    }

    var instance = {
        Field: field,
        Reset: reset_robot_state,
        Execute: function (code, check_result_correct = check_correct_execute) {
            try {
                reset_robot_state();
                var f = new Function('Robot', 'Directions', 'Checks', code);
                f(queue_controler, RobotConstants.Directions, RobotConstants.CheckVariants);
                queue.Add(check_result_correct);
                reset_robot_state();
                queue.Execute();
                queue.Clear();
            } catch {
                alert('Некорректный код!')
            }
        },
        CheckResults: check_execute_result,
        GetResultString: get_check_correct_execute_string,
        DefoultCheckCorrectExecute: check_correct_execute
    };

    return instance;
}

/**
 * Создание API для робота c некоторым начальным полем.
 *
 * @param {String[]} pattern Строки для поля. 
 * @param {Number} start_pos_x Стартовая позиция робота по X.
 * @param {Number} start_pos_y Стартовая позиция робота по Y.
 * @param {HTMLElement} html_loger Элемент логера.
 * @param {Number} queue_delay Задержка.
 */
export function CreateFullRobotAPIWithPattern(pattern, start_pos_x, start_pos_y, html_loger, queue_delay) {
    var height = pattern.length;
    var width = pattern[0].length;

    var api = CreateFullRobotAPI(width, height, false, start_pos_x, start_pos_y, html_loger, queue_delay);

    for (var y = 0; y < height; y++) {
        for (var x = 0; x < width; x++) {
            var cell = api.Field.Rows[y].Columns[x];
            switch (pattern[y][x]) {
                case '.':
                    cell.Controls.SetContentVoid();
                    break;
                case '#':
                    cell.Controls.SetContentWall();
                    break;
                case 'F':
                    cell.Controls.SetContentFlag();
                    break;
                case '*':
                    cell.Controls.SetContentFinish();
                    break;
            }
        }
    }

    api.Reset();

    return api;
}