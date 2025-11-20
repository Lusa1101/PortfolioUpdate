import { Component } from '@angular/core';
import { experienceData, sectionClass } from '../../app/data';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-experiences',
  imports: [CommonModule],
  templateUrl: './experiences.html',
  styleUrl: './experiences.css'
})
export class Experiences {
  experiences = experienceData;
  styles = sectionClass;

  returnPosition(index: number) {
    return index % 2 === 0 ? "flex flex-col items-start gap-2 m-2" : "flex flex-col items-end gap-2 m-2";
  }

  returnStrokePosition(index: number) {
  return index % 2 === 0 ? "block w-0.5 max-h-full bg-[#677e7c] items-end" : "block w-0.5 max-h-full bg-[#677e7c] items-start";
  }

  returnTextPosition(index: number) {
    return index % 2 === 0 ? "items-end text-end" : "items-start text-start";
  }
}
