/**
 * Тип клетки.
 * @typedef {Object} CellContent
 *
 * @property {Number} Value Индекс.
 * @property {String} Char Символ.
 */

/**
 * Варианты типов клетки.
 * @typedef {Object} CellContents
 *
 * @property {CellContent} Void Пустая клетка.
 * @property {CellContent} Wall Стена.
 */
export const CellContents = {
    /**
     * Пустая клетка.
     * @type {CellContent}
     */
    Void: { Value: 0, Char: '&nbsp;' },
    /**
     * Стена.
     * @type {CellContent}
     */
    Wall: { Value: 1, Char: '#' }
}

/**
 * Цвет клетки.
 * @typedef {Object} CellColor
 *
 * @property {Number} Value Номер цвета.
 * @property {String} Color Цвет текста.
 * @property {String} BackgroundColor Цвет фона.
 */

/**
 * Варианты цветов клетки.
 * @typedef {Object} CellColors
 *
 * @property {CellColor} Void Пустая клетка.
 * @property {CellColor} Filled Закрашенная клетка.
 */
export const CellColors = {
    /**
     * Пустая клетка.
     * @type {CellColor}
     */
    Void: { Value: 0, Color: '#000000', BackgroundColor: '#FFFFFF' },
    /**
     * Закрашенная клетка.
     * @type {CellColor}
     */
    Filled: { Value: 1, Color: '#FFFFFF', BackgroundColor: '#000000' }
}