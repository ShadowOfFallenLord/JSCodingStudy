/**
 * Смещение для направления.
 * @typedef {Object} Offset
 *
 * @property {Number} X Смещение по X.
 * @property {Number} Y Смещение по Y.
 */

/**
 * Направление.
 * @typedef {Object} Direction
 *
 * @property {Offset} Offset Смещение.
 * @property {String} Text Описание.
 */

/**
 * Перечисление направлений.
 * @typedef {Object} Directions
 *
 * @property {Direction} Up Направление вверх.
 * @property {Direction} Right Направление вправо.
 * @property {Direction} Down Направление вниз.
 * @property {Direction} Left Направление влево.
 */
export const Directions = {
    /**
     * Направление вверх.
     * @type {Direction}
     */
    Up: { Offset: { X: 0, Y: -1 }, Text: "Вверх" },

    /**
     * Направление вправо.
     * @type {Direction}
     */
    Right: { Offset: { X: 1, Y: 0 }, Text: "Вправо" },

    /**
     * Направление вниз.
     * @type {Direction}
     */
    Down: { Offset: { X: 0, Y: 1 }, Text: "Вниз" },

    /**
     * Направление влево.
     * @type {Direction}
     */
    Left: { Offset: { X: -1, Y: 0 }, Text: "Влево" },
}

/**
 * Оторражение содержимого клетки с роботом.
 * @type {String}
 */
export const RobotCellContent = '@'

/**
 * Что проверяем.
 * @typedef {Object} CheckVariant
 *
 * @property {Number} Id Номер варианта.
 * @property {String} Text Текст.
 */

/**
 * Что проверяем.
 * @typedef {Object} CheckVariants
 *
 * @property {CheckVariant} Void Клетка пуста.
 * @property {CheckVariant} Wall Клетка стена.
 * @property {CheckVariant} Clear Клетка чиста.
 * @property {CheckVariant} Filled Клетка закрашенна.
 */
export const CheckVariants = {
    /**
     * Клетка пуста.
     * @type {CheckVariant}
     */
    Void: { Id: 0, Text: 'Пусто' },

    /**
     * Клетка стена.
     * @type {CheckVariant}
     */
    Wall: { Id: 1, Text: 'Стена' },

    /**
     * Клетка чиста.
     * @type {CheckVariant}
     */
    Clear: { Id: 2, Text: 'Чисто' },

    /**
     * Клетка закрашенна.
     * @type {CheckVariant}
     */
    Filled: { Id: 3, Text: 'Закрашено' },
}