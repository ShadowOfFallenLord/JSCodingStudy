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
 * @property {CellContent} Flag Флаг.
 * @property {CellContent} UsedFlag Посещенный флаг.
 * @property {CellContent} Wall Финальная точка.
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
    Wall: { Value: 1, Char: '#' },
    /**
     * Флаг.
     * @type {CellContent}
     */
    Flag: { Value: 2, Char: 'F' },
    /**
     * Посещенный флаг.
     * @type {CellContent}
     */
    UsedFlag: { Value: 3, Char: '!' },
    /**
     * Финальная точка.
     * @type {CellContent}
     */
    Finish: { Value: 4, Char: '*' },
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