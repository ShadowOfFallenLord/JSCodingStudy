/**
 * Основной объект робота.
 * @typedef {Object} Robot
 *
 * @property {Boolean} Destroed Уничтожен ли робот.
 * @property {Number} X Текущее положение по Х.
 * @property {Number} Y Текущее положение по Y
 * @property {Number} OldX Последнее положение по X.
 * @property {Number} OldY Последнее положение по Y.
 */

/**
 * Создать объект робота
 * @param {Number} x Позиция по X.
 * @param {Number} y Позиция по Y.
 */
export function CreateRobot(x, y) {
    /**
     * @type {Robot}
     */
    var player = {
        Destroed: false,
        X: x,
        Y: y,
        OldX: x,
        OldY: y,
    }
    return player;
}