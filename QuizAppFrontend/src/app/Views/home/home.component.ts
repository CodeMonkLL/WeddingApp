import { Component } from '@angular/core';
import { NavbarComponent } from '../../Components/navbar/navbar.component';
import { QuizComponent } from '../../Components/quiz/quiz.component';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [NavbarComponent, NgIf],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
  standalone: true,
})
export class HomeComponent {
  isOpen = false;

  toggle() {
    this.isOpen = !this.isOpen;
  }
}
