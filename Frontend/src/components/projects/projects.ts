import { Component } from '@angular/core';
import { projectsData, sectionClass } from '../../app/data';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-projects',
  imports: [CommonModule],
  templateUrl: './projects.html',
  styleUrl: './projects.css'
})
export class Projects {
  styles = sectionClass;
  projects = projectsData;

  // Domains for filtering
  domains = ['All', 'AI', 'Robotics', 'IoT', 'Software Engineering', 'Hackathons'];
}
