import { Component, Input } from '@angular/core';

@Component({
  selector: 'p-input',
  templateUrl: './p-input.componen.html',
  styleUrls: ['./p-input.component.scss']
})
export default class PInputComponent {
  @Input('p-type') type: 'text' | 'password' = 'text';
  @Input('p-placeholder') placeholder: string = '';
  @Input('p-style') style: 'fill' | 'default' = 'default';
}
