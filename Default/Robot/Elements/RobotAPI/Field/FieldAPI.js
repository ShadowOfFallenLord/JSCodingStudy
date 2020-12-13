import * as Constants from './FieldConstans.js'

/**
 * Функции клетки поля.
 * @typedef {Object} RobotFieldCellFunctions
 *
 * @property {Function} SetColorVoid Сделать клетку чистой.
 * @property {Function} SetColorFill Сделать клетку закрашенной.
 * @property {Function} SetContentVoid Сделать клетку пустой.
 * @property {Function} SetContentWall Сделать клетку Стеной.
 */

/**
 * Клетка поля.
 * @typedef {Object} RobotFieldCell
 *
 * @property {HTMLElement} CellElement Элемент клетки в DOM-дереве (td).
 * @property {Constants.CellContent} Content Сожержимое.
 * @property {Constants.CellColor} Color Цвет.
 * @property {RobotFieldCellFunctions} Controls Функции обработки.
 */

/**
 * Строка поля.
 * @typedef {Object} RobotFieldRow
 *
 * @property {HTMLElement} RowElement Элемент строки в DOM-дереве (tr).
 * @property {RobotFieldCell[]} Columns Элементы строки.
 */

/**
 * Поле для робота.
 * @typedef {Object} RobotField
 *
 * @property {Number} Width Ширина поля в клетках.
 * @property {Number} Height Высота поля в клетках.
 * @property {HTMLElement} FieldElement Элемент поля в DOM-дереве (table).
 * @property {RobotFieldRow[]} Rows Массив строк таблицы поля.
 * @property {RobotFieldCell[]} DrawedElements Закрашенные клетки.
 * @property {Function} Clear Закрашенные клетки.
 */

/**
 * Создание поля.
 *
 * @param {Number} width Ширина поля в клетках.
 * @param {Number} height Высота поля в клетках.
 * @param {Boolean} manual_walls_installation Можно ли вручную устанавливать стены, кликая по клеткам.
 */
export function CreateGameField(width, height, manual_walls_installation) {
    /**
     * Установка цвета элемента.
     *
     * @param {HTMLElement} html_element Элемент.
     * @param {Constants.CellColor} color Цвет.
     */
    function html_set_color(html_element, color) {
        html_element.style.backgroundColor = color.BackgroundColor;
        html_element.style.color = color.Color;
    }

    /**
     * Установка содержимого элемента.
     *
     * @param {HTMLElement} html_element Элемент.
     * @param {Constants.CellContent} content Содержимое.
     */
    function html_set_content(html_element, content) {
        html_element.innerHTML = content.Char;
    }

    /**
     * @type {RobotField}
     */
    var result = {
        /**
         * Ширина поля в клетках.
         * @type {Number}
         */
        Width: width,

        /**
         * Высота поля в клетках.
         * @type {Number}
         */
        Height: height,

        /**
         * Элемент поля в DOM-дереве.
         * @type {HTMLElement}
         */
        FieldElement: document.createElement('table'),

        /**
         * Массив строк таблицы поля.
         * @type {RobotFieldRow[]}
         */
        Rows: [],

        /**
         * Закрашенные клетки.
         * @type {RobotFieldCell[]}
         */
        DrawedElements: [],

        /**
         * Функция очистки цветов поля.
         * @type {Function}
         */
        Clear: null
    }

    result.Clear = function () {
        result.DrawedElements.forEach(item => {
            var cell_element = item.CellElement;
            html_set_color(cell_element, Constants.CellColors.Void);
        });
        result.DrawedElements = [];
    }

    for (var i = 0; i < height; i++) {
        var html_elem = document.createElement('tr');
        html_elem.setAttribute('align', 'center');
        result.FieldElement.append(html_elem);
        result.Rows[i] = {
            /**
             * Элемент строки в DOM-дереве (tr).
             * @type {HTMLElement}
             */
            RowElement: html_elem,

            /**
             * Элементы строки.
             * @type {RobotFieldRow[]}
             */
            Columns: []
        }
    }

    for (var y = 0; y < height; y++) {
        var row_parrent = result.Rows[y].RowElement;
        var row_array = result.Rows[y].Columns;
        for (var x = 0; x < width; x++) {
            var html_element = document.createElement('td');
            html_element.setAttribute('width', '19px')
            html_set_content(html_element, Constants.CellContents.Void);
            html_set_color(html_element, Constants.CellColors.Void);
            row_parrent.append(html_element);

            /**
             * Клетка.
             * @type {RobotFieldCell}
             */
            var cell = {
                CellElement: html_element,
                Content: Constants.CellContents.Void,
                Color: Constants.CellColors.Void,
                Controls: null,
            }

            function GetSetColorVoidFunction(current_cell) {
                return function () {
                    current_cell.Color = Constants.CellColors.Void;
                    html_set_color(current_cell.CellElement, Constants.CellColors.Void);
                }
            }

            function GetSetColorFillFunction(current_cell) {
                return function () {
                    current_cell.Color = Constants.CellColors.Filled;
                    html_set_color(current_cell.CellElement, Constants.CellColors.Filled);
                    result.DrawedElements.push(current_cell);
                }
            }

            function GetSetContentVoidFunction(current_cell) {
                return function () {
                    current_cell.Content = Constants.CellContents.Void;
                    html_set_content(current_cell.CellElement, Constants.CellContents.Void);
                }
            }

            function GetSetContentWallFunction(current_cell) {
                return function () {
                    current_cell.Content = Constants.CellContents.Wall;
                    html_set_content(current_cell.CellElement, Constants.CellContents.Wall);
                }
            }

            cell.Controls = {
                SetColorVoid: GetSetColorVoidFunction(cell),
                SetColorFill:  GetSetColorFillFunction(cell),
                SetContentVoid:  GetSetContentVoidFunction(cell),
                SetContentWall:  GetSetContentWallFunction(cell),
            };

            if (manual_walls_installation) {
                function SetWallOnClickFunction(current_cell) {
                    current_cell.CellElement.onclick = function () {
                        if (current_cell.Content == Constants.CellContents.Void) {
                            current_cell.Controls.SetContentWall();
                        } else {
                            current_cell.Controls.SetContentVoid();
                        }
                    }
                }

                SetWallOnClickFunction(cell);
            }

            row_array[x] = cell;
        }
    }

    return result;
}