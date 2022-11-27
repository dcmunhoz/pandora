import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  protected mensagem: string = 'Olá mundo;';
  protected inputModel: string = '';

  protected form: FormGroup;

  constructor(private readonly _fb: FormBuilder) {
    this.form = this._fb.group({
      label1: ['', Validators.required]
    });
  }

  public clickTest(): void {
    console.log(this.form.value);
    console.log(this.form.invalid);
  }
}
