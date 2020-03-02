/**
* @fileOverview
* @author Zoltan Toth
* @version 1.1.0
*/

/**
* @description
* Vanilla JavaScript Accordion
*
* @class
* @param {(string|Object)} options.element - HTML id of the accordion container
*         or the DOM element.
* @param {number} [options.openTab=1] - Start the accordion with this item opened.
* @param {boolean} [options.oneOpen=false] - Only one tab can be opened at a time.
*/
var Accordion = function(options) {
    var element = typeof options.element === 'string' ?
                    document.getElementById(options.element) : options.element,
        openTab = options.openTab,
        oneOpen = options.oneOpen || false,

        titleClass   = 'js-accordion-title',
        contentClass = 'js-accordion-content';

    render();

    /**
     * Initial rendering of the accordion.
     */
    function render() {
        // attach classes to buttons and containers
        [].forEach.call(element.querySelectorAll('button'),
            function(item) {
                item.classList.add(titleClass);
                item.nextElementSibling.classList.add(contentClass);
            });

        // attach only one click listener
        element.addEventListener('click', onClick);

        // accordion starts with all tabs closed
        closeAll();

        // sets the open tab - if defined
        if (openTab) {
            open(openTab);
        }
    }

    /**
     * Handles clicks on the accordion.
     *
     * @param {object} e - Element the click occured on.
     */
    function onClick(e) {
        if (e.target.className.indexOf(titleClass) === -1) {
            return;
        }
        // if (oneOpen) {
        //     closeAll();
        // }
        [].forEach.call(element.querySelectorAll('.' + contentClass), function(item) {
            item.style.height = 0;
        });
        //toggle(e.target.nextElementSibling);
        el = e.target.nextElementSibling;

        var height = el.scrollHeight;

        if(e.target.classList.contains('activo')){
            el.style.height = 0;
            e.target.closest(".item-ac").classList.remove('activo');
            e.target.classList.remove('activo');
        } else {
            el.style.height = height + 'px';
            [].forEach.call(element.querySelectorAll('.' + titleClass), function(item) {
                item.closest(".item-ac").classList.remove('activo');
                item.classList.remove('activo');
            });
            e.target.closest(".item-ac").classList.add('activo');
            e.target.classList.add('activo');
        }

        // if(e.target.classList.contains('activo')){
        //   e.target.classList.remove('activo');
        //   closeAll();
        // } else {
        //   e.target.classList.add('activo');
        // }
    }

    /**
     * Closes all accordion tabs.
     */
    function closeAll() {
        [].forEach.call(element.querySelectorAll('.' + contentClass), function(item) {
            item.style.height = 0;
        });
    }

    /**
     * Toggles corresponding tab for each title clicked.
     *
     * @param {object} el - The content tab to show or hide.
     */
    function toggle(el) {
        // getting the height every time in case
        // the content was updated dynamically
        var height = el.scrollHeight;

        if (el.style.height === '0px' || el.style.height === '') {
            el.style.height = height + 'px';
        } else {
            el.style.height = 0;
        }
    }


    /**
     * Returns the corresponding accordion content element by index.
     *
     * @param {number} n - Index of tab to return
     */
    function getTarget(n) {
        return element.querySelectorAll('.' + contentClass)[n - 1];
    }

    /**
     * Opens a tab by index.
     *
     * @param {number} n - Index of tab to open.
     *
     * @public
     */
    function open(n) {
        var target = getTarget(n);

        if (target) {
            if (oneOpen) closeAll();
            target.style.height = target.scrollHeight + 'px';
        }
    }

    /**
     * Closes a tab by index.
     *
     * @param {number} n - Index of tab to close.
     *
     * @public
     */
    function close(n) {
        var target = getTarget(n);

        if (target) {
            target.style.height = 0;
        }
    }

    /**
     * Destroys the accordion.
     *
     * @public
     */
    function destroy() {
        element.removeEventListener('click', onClick);
    }

    return {
        open: open,
        close: close,
        destroy: destroy
    };
};