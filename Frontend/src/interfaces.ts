export interface Project {
  id: number;
  name: string;
  description: string;
  technologyStack: string;
  startDate: Date;
  endDate: Date;
  githubUrl: string;
}

export interface ProjectImage {
    id: number;
    projectId: number;
    file: string;
}

export interface TechnologyStack {
    name: string; 
    count: number;
}

export interface ProjectStack {
    projects: Project[];
    technologyStack: TechnologyStack[];
}

export interface Experience {
    id: number;
    // organization: string;
    name: string;
    description: string;
    startDate: Date;
    endDate: Date;
    // role: string;
}

export interface Certificate {
    id: number;
    title: string;
    description: string;
    issuer: string;
    issueDate: Date;
    credentialId: string;
    verificationLink: string;
}

export interface Qualification {
    id: number;
    name: string;
    // institution: string;
    description: string;
    startDate: Date;
    endDate: Date;
}

export interface JourneyData {
    id: number;
    type: string;
    date: string;
    name: string;
    description: string;
}