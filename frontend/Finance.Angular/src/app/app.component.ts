import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  protected mensagem: string = 'Olá mundo;';
  protected inputModel: string = '';

  public clickTest(): void {
    console.log('mensagem');
  }
}
