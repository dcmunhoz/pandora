import { Component, Input } from '@angular/core';

@Component({
  selector: 'p-loading-overlay',
  templateUrl: './p-loading-overlay.component.html',
  styleUrls: ['./p-loading-overlay.component.scss']
})
export class PLoadinOverlayComponent {
  @Input('p-message') message: string = '';
}
