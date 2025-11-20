import { Component } from '@angular/core';
import { qualificationsData, sectionClass } from '../../app/data';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-qualifications',
  imports: [CommonModule],
  templateUrl: './qualifications.html',
  styleUrl: './qualifications.css'
})
export class Qualifications {
  styles = sectionClass;
  qualifications = qualificationsData;
}
