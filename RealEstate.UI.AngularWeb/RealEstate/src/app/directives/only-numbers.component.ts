import { Directive, ElementRef, Input, HostListener } from "@angular/core";

@Directive({
    selector: '[OnlyNumbers]'
})
export class OnlyNumberDirective {

    regexStr = '^[0-9]*$';
    constructor(private el: ElementRef) { }

    @HostListener('keydown', ['$event']) onKeyDown(event) {

        let e = <KeyboardEvent>event;

        if ([46, 8, 9, 27, 13].indexOf(e.keyCode) !== -1 ||
            // Allow: Ctrl+A
            (e.keyCode == 65 && e.ctrlKey === true) ||
            // Allow: Ctrl+C
            (e.keyCode == 67 && e.ctrlKey === true) ||
            // Allow: Ctrl+V
            (e.keyCode == 86 && e.ctrlKey === true) ||
            // Allow: Ctrl+X
            (e.keyCode == 88 && e.ctrlKey === true) ||
            // Allow: home, end, left, right
            (e.keyCode >= 35 && e.keyCode <= 39) ||
            //Allow numeric keyboard keys
            (e.keyCode >= 96 && e.keyCode <= 105)) {
            // let it happen, don't do anything
            return;
        }
        let ch = String.fromCharCode(e.keyCode);
        
        let regEx = new RegExp(this.regexStr);
        if (regEx.test(ch))
            return;
        else
            e.preventDefault();
    }
}

