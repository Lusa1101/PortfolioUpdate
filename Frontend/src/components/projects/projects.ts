import { Component, OnInit } from '@angular/core';
import { projectsData, sectionClass } from '../../app/data';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { Database } from '../../services/database';
import { Project, ProjectImage } from '../../interfaces';
@Component({
  selector: 'app-projects',
  imports: [CommonModule],
  templateUrl: './projects.html',
  styleUrl: './projects.css'
})
export class Projects {
  styles = sectionClass;
  projects: Project[] = [];
  projectImages: ProjectImage[] = [];
  showImage = false;
  selectedImage = '';

  // Domains for filtering
  domains = ['All', 'AI', 'Software Engineering', 'Hackathons'];

  constructor(private db: Database) {}

  ngOnInit() {
    this.fetchProjects();
  }

  async fetchProjects(){
    await this.db.getProjects().then((data) => {
      data.subscribe(x => {
        this.projects = x.projects;
      });
    });

    await this.db.getProjectImage().then((data) => {
      data.subscribe(x => {
        this.projectImages = x;
        // console.log('Project Images fetched: ', this.projectImages);
      });
    })
  }

  filterImagesById(projectId: number) {
    var images = this.projectImages
      .filter(img => img.projectId === projectId);

    // console.log('Filtered Images for Project ID ', projectId, ': ', images);
    return images[images.length - 1]?.file;
  }

  selectImage(imageUrl: string) {
    this.showImage = true;
    this.selectedImage = imageUrl;
  }
}
