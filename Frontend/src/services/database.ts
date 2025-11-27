import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Certificate, Experience, ProjectStack, Qualification } from '../interfaces';
import { Qualifications } from '../components/qualifications/qualifications';

@Injectable({
  providedIn: 'root'
})
export class Database {
  // Variables needed 
  baseUrl = 'https://localhost:7275/';
  projectsUrl = this.baseUrl + 'Projects/GetProjects';
  projectImagesUrl = this.baseUrl + 'ProjectImages/GetProjectImages';
  experienceUrl = this.baseUrl + 'Experiences/GetExperiences';
  certificatesUrl = this.baseUrl + 'Certificates/GetCertificates';
  qualificationsUrl = this.baseUrl + 'Qualifications/GetQualifications';

  // Constructor to inject necessary services
  constructor(private http: HttpClient) { }

  async getProjects() {
    return this.http.get<ProjectStack>(this.projectsUrl);
  }

  async getProjectImage() {
    return await this.http.get<any>(this.projectImagesUrl);
  }

  async getProjectImagesByProjectId(projectId: number) {
    return await this.http.get<any>(this.projectImagesUrl + `?projectId=${projectId}`);
  }

  async getCertificates() {
    return await this.http.get<Certificate>(this.certificatesUrl);
  }

  async getExperience() {
    return await this.http.get<Experience>(this.experienceUrl);
  }

  async getQualifications() {
    return await this.http.get<Qualification>(this.qualificationsUrl);
  }
}
