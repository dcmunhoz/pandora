import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'p-button',
  templateUrl: './p-button.component.html',
  styleUrls: ['./p-button.component.scss']
})
export class PButtonComponent {
  @Input('p-text') text: string = '';
  @Input('p-style') style: 'normal' | 'fill' = 'normal';
  @Input('p-type') type: 'normal' | 'danger' = 'normal';
  @Input('p-size') size: 'sm' | 'md' | 'lg' = 'md';

  @Output('p-click') clickAction = new EventEmitter<null>();

  protected emitClick(): void {
    this.clickAction.emit(null);
  }
}

