import { Component } from '@angular/core';
import { sectionClass, skillsData } from '../../app/data';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-skills',
  imports: [CommonModule],
  templateUrl: './skills.html',
  styleUrl: './skills.css'
})
export class Skills {
  data = skillsData;
  styles = sectionClass;
}
