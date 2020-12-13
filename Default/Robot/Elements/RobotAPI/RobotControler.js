import * as FieldAPI from './Field/FieldAPI.js'
import * as FieldConstants from './Field/FieldConstans.js'
import * as RobotAPI from './Robot/RobotAPI.js'
import * as RobotConstants from './Robot/RobotConstants.js'

/**
 * Управление роботом.
 * @typedef {Object} RobotControler
 *
 * @property {RobotAPI.Robot} Robot Сущность робота.
 * @property {Function} Move Подвинуть робота.
 * @property {Function} Check Осмотреть клетку.
 * @property {Function} Draw ЗАкрасить клетку.
 * @property {Function} ReDrawField Перерисовать роле.
 */

/**
 * Создание контроллера для робота.
 *
 * @param {Number} x Позиция по X.
 * @param {Number} y Позиция по Y.
 * @param {FieldAPI.RobotField} field Поле для робота.
 */
export function CreateRobotControler(x, y, field) {

    var robot_instance = RobotAPI.CreateRobot(x, y);

    function check_in_in_field(x, y) {
        if (x < 0 || x >= field.Width) return false;
        if (y < 0 || y >= field.Height) return false;
        return true;
    }

    /**
     * Экземпляр робота
     * @type {RobotControler}
     */
    var instance = {
        /**
         * Экземпляр робота
         * @type {RobotAPI.Robot}
         */
        Robot: robot_instance,

        /**
         * Перемещение робота на 1 клетку
         * @param {RobotConstants.Direction} direction Направление
         */
        Move: function (direction) {
            if (robot_instance.Destroed) return;

            var x = robot_instance.X + direction.Offset.X;
            var y = robot_instance.Y + direction.Offset.Y;

            var is_in_field = check_in_in_field(x, y);

            if (!is_in_field || field.Rows[y].Columns[x].Content.Value == FieldConstants.CellContents.Wall.Value) {
                robot_instance.Destroed = true;
                return;
            }

            robot_instance.X += direction.Offset.X;
            robot_instance.Y += direction.Offset.Y;
        },

        /**
         * Проверить клетку 
         * @param {RobotConstants.Direction} direction Направление
         * @param {RobotConstants.CheckVariant} variant Что проверяем 
         */
        Check: function (direction, variant) {
            if (robot_instance.Destroed) return;

            var x = robot_instance.X + direction.Offset.X;
            var y = robot_instance.Y + direction.Offset.Y;

            var is_in_field = check_in_in_field(x, y);

            if (!is_in_field) {
                if (variant.Id == RobotConstants.CheckVariants.Wall.Id) {
                    return true;
                } else {
                    return false;
                }
            }

            var cell = field.Rows[y].Columns[x];
            switch (variant.Id) {
                case RobotConstants.CheckVariants.Void.Id:
                    return cell.Content.Value == FieldConstants.CellContents.Void.Value;
                case RobotConstants.CheckVariants.Wall.Id:
                    return cell.Content.Value == FieldConstants.CellContents.Wall.Value;
                case RobotConstants.CheckVariants.Clear.Id:
                    return cell.Color.Value == FieldConstants.CellColors.Void.Value;
                case RobotConstants.CheckVariants.Filled.Id:
                    return cell.Color.Value == FieldConstants.CellColors.Filled.Value;
            }
        },

        /**
         * Закрасить клетку
         */
        Draw: function () {
            if (robot_instance.Destroed) return;

            var cell = field.Rows[robot_instance.Y].Columns[robot_instance.X];
            cell.Controls.SetColorFill();
        },

        /**
         * Перерисовать поле
         */
        ReDrawField: function () {
            var cell = field.Rows[robot_instance.Y].Columns[robot_instance.X];
            var old_cell = field.Rows[robot_instance.OldY].Columns[robot_instance.OldX];

            old_cell.CellElement.innerHTML = old_cell.Content.Char;
            cell.CellElement.innerHTML = RobotConstants.RobotCellContent;

            robot_instance.OldX = robot_instance.X;
            robot_instance.OldY = robot_instance.Y;
        }
    };

    return instance;
}