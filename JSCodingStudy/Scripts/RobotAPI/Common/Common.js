/**
 * Логер.
 * @typedef {Object} Loger
 *
 * @property {Function} Add Записать в лог.
 * @property {Function} Clear Очистить лог.
 */

/**
 * Создать логер
 * @param {HTMLElement} html html-элемент.
 */
export function CreateLoger(html) {
    /**
     * @type {Loger}
     */
    var loger = {
        Add: function(message) {
            var text = html.innerHTML;
            text = text + message + '\n';
            html.innerHTML = text;
        },
        Clear: function() {
            html.innerText = '';
        }
    }
    return loger;
}

/**
 * Очередь исполнения.
 * @typedef {Object} ExecutionQueue
 *
 * @property {Function} Add Добавить объект в очередь.
 * @property {Function} Execute Выполнить очередь.
 * @property {Function} Clear Очистить.
 */

/**
 * Создать очечедь исполнения
 * @param {Number} delay Задержка.
 */
export function CreateExecutionQueue(delay) {
    var list = [];
    /**
     * @type {ExecutionQueue}
     */
    var instance = {
        /**
         * Добавить объект в очередь.
         * @param {Function} elem Добавляемая функция. 
         */
        Add: function(elem) {
            list.push(elem);
        },

        /**
         * Выполнить функции из очереди
         */
        Execute: function() {
            list.forEach((elem, i) => {
                setTimeout(elem, (i + 1) * delay);
            });
        },

        /**
         * Очистить очередь
         */
        Clear: function() {
            list = [];
        },
    };

    return instance;
}