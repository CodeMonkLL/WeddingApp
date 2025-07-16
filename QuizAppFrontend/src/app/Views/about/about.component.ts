import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { ChangeDetectionStrategy, signal } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
@Component({
  selector: 'app-about',
  imports: [MatCardModule, MatExpansionModule, MatIcon],
  templateUrl: './about.component.html',
  styleUrl: './about.component.scss',
})
export class AboutComponent {
  readonly panel1OpenState = signal(false);
  readonly panel2OpenState = signal(false);
  readonly panel3OpenState = signal(false);
}
