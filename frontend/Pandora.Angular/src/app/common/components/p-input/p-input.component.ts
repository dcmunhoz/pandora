import { Component, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

import { generateId } from './../../utils/utils';

@Component({
  selector: 'p-input',
  templateUrl: './p-input.componen.html',
  styleUrls: ['./p-input.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => PInputComponent),
      multi: true
    }
  ]
})
export default class PInputComponent implements ControlValueAccessor {
  @Input('p-type') type: 'text' | 'password' = 'text';
  @Input('p-placeholder') placeholder: string = '';
  @Input('p-style') style: 'fill' | 'default' = 'default';
  @Input('p-label') label: string = '';
  @Input('p-size') size: 'sm' | 'md' | 'lg' = 'sm';
  @Input('p-error') error: boolean = false;

  private _onChange = (value: any): void => {};
  private _onTouched = (value: any): void => {};

  protected field: any;
  public set value(val: any) {
    this.field = val;
    this._onChange(val);
    this._onTouched(val);
  }

  protected id: string = '';

  constructor() {
    this.id = 'p-input-' + generateId();
  }

  public writeValue(value: any): void {
    this.value = value;
  }

  public registerOnChange(fn: any): void {
    this._onChange = fn;
  }

  public registerOnTouched(fn: any): void {
    this._onTouched = fn;
  }
}
