export const projectsData = [
  {
    title: "AI Crop Doctor",
    description:
      "An AI-powered diagnostic tool for agricultural applications, helping farmers identify plant diseases through image recognition.",
    tags: ["Python", "TensorFlow", "FastAPI"],
    imageUrl: "projectImageMap",
    imageHint: "project-1",
    category: "AI",
  },
  {
    title: "Eco-Drone",
    description:
      "Developed firmware for an autonomous drone for environmental monitoring, capable of collecting air and water quality data.",
    tags: ["C++", "IoT", "PlatformIO"],
    imageUrl: "project-2",
    imageHint: "project-2",
    category: "Robotics",
  },
  {
    title: "Smart Energy Hub",
    description:
      "A smart home system leveraging IoT sensors and ASP.NET Core to monitor and optimize energy consumption in real-time.",
    tags: ["ASP.NET Core", "IoT", "Angular"],
    imageUrl: "project-3",
    imageHint: "project-3",
    category: "IoT",
  },
  {
    title: "Artisan Connect",
    description:
      "A cross-platform mobile app built with .NET MAUI for a freelance client, connecting local artisans with customers.",
    tags: [".NET MAUI", "SQLite", "Azure"],
    imageUrl: "project-4",
    imageHint: "project-4",
    category: "Software Engineering",
  },
  {
    title: "Campus Eats",
    description:
      "A full-stack web application for university students to order food from campus canteens. Built with React and ASP.NET Core.",
    tags: ["React", "ASP.NET Core", "SQL Server"],
    imageUrl: "project-5",
    imageHint: "project-5",
    category: "Software Engineering",
  },
  {
    title: "Hack4Good Solution",
    description:
      "A web platform developed during a hackathon to coordinate volunteer efforts for local community projects.",
    tags: ["Angular", "Firebase", "Google Maps API"],
    imageUrl: "project-6",
    imageHint: "project-6",
    category: "Hackathons",
  },
];

export const skillsData = [
  {
    name: ".NET MAUI",
    icon: "Smartphone",
    description: "Building cross-platform mobile apps for iOS and Android.",
  },
  {
    name: "ASP.NET Core",
    icon: "Server",
    description: "Developing robust and scalable back-end services and APIs.",
  },
  {
    name: "Python for ML",
    icon: "Bot",
    description: "Using Python with libraries like TensorFlow and PyTorch for ML.",
  },
  {
    name: "C/C++",
    icon: "Cpu",
    description: "Low-level programming for robotics and high-performance systems.",
  },
  {
    name: "Java",
    icon: "Code",
    description: "Enterprise-level application development.",
  },
  {
    name: "Angular",
    icon: 'Code',
    description: "Building dynamic single-page applications for the web.",
  },
  {
    name: "React Native",
    icon: "Smartphone",
    description: "Exploring another avenue for cross-platform app development.",
  },
  {
    name: "IoT",
    icon: "Leaf",
    description: "Connecting the physical and digital worlds with smart devices."
  }
];

export const experienceData = [
  {
    type: "Education",
    title: "BSc in Computer Science",
    location: "University of Venda, South Africa",
    description: "Graduated with a solid foundation in computer science principles, algorithms, and software development.",
    date: "2020 - 2023",
    icon: "GraduationCap",
  },
  {
    type: "Work",
    title: "Freelance Developer",
    location: "Remote",
    description:
      "Developed custom software solutions for various clients, including mobile apps and web platforms, from conception to deployment.",
    date: "2022 - Present",
    icon: "Briefcase",
  },
  {
    type: "Hackathon",
    title: "Coach @ Hack-for-Change",
    location: "Johannesburg, South Africa",
    description:
      "Mentored and coached teams of student hackers, providing technical guidance and support to help them build innovative solutions.",
    date: "2023",
    icon: "Trophy",
  },
  {
    type: "Hackathon",
    title: "Participant @ Data-Driven-Decisions",
    location: "Cape Town, South Africa",
    description: "Participated in a data science hackathon, developing a predictive model for urban traffic flow.",
    date: "2022",
    icon: "Trophy",
  },
];

export const qualificationsData = [
    {
        name: "BSc in Computer Science",
        issuer: "University of Venda",
        date: "Dec 2023",
        downloadUrl: "#"
    },
    {
        name: "Certified C# Developer",
        issuer: "Microsoft",
        date: "Jun 2023",
        downloadUrl: "#"
    },
    {
        name: "Python for Everybody Specialization",
        issuer: "Coursera",
        date: "Jan 2022",
        downloadUrl: "#"
    }
];

export const socialLinks = [
    { name: "GitHub", url: "https://github.com", icon: "Github" },
    { name: "LinkedIn", url: "https://linkedin.com", icon: "Linkedin" },
    { name: "Email", url: "mailto:email@example.com", icon: "Mail" },
]

export const blogPosts = [
  {
    slug: "my-journey-into-ai",
    title: "My Journey Into AI and Machine Learning",
    summary: "A personal story of how I fell in love with artificial intelligence and the projects I've worked on.",
    author: "Omphulusa Mashau",
    date: "2024-07-20",
    imageUrl: "https://picsum.photos/seed/blog1/800/400",
    imageHint: "AI machine learning",
    content: `
      <p>My fascination with AI began during my second year at the University of Venda. I stumbled upon a lecture about neural networks, and I was immediately hooked. The idea that we could create machines that learn and think like humans was mind-blowing. This led me down a rabbit hole of online courses, research papers, and personal projects.</p>
      <p>One of my first projects was the <strong>AI Crop Doctor</strong>, a tool to help farmers diagnose plant diseases. It was a challenging but incredibly rewarding experience that solidified my passion for using AI to solve real-world problems.</p>
      <p>Here’s a look at the process:</p>
      <div class="aspect-w-16 aspect-h-9 my-6">
        <iframe src="https://www.youtube.com/embed/dQw4w9WgXcQ" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
      </div>
      <p>I believe AI has the potential to revolutionize industries and improve countless lives. I'm excited to be a part of this journey and to continue exploring the endless possibilities of artificial intelligence.</p>
    `,
    comments: [
      { id: "1", author: "Jane Doe", text: "This is so inspiring! Thanks for sharing your journey." },
      { id: "2", author: "John Smith", text: "Great post! The AI Crop Doctor sounds like an amazing project." }
    ]
  },
  {
    slug: "building-the-eco-drone",
    title: "Building the Eco-Drone: A Deep Dive into IoT and Robotics",
    summary: "A technical overview of the development process behind the Eco-Drone, my autonomous drone for environmental monitoring.",
    author: "Omphulusa Mashau",
    date: "2024-07-15",
    imageUrl: "https://picsum.photos/seed/blog2/800/400",
    imageHint: "drone robotics",
    content: `
      <p>The Eco-Drone was one of the most ambitious projects I've undertaken. The goal was to create a drone that could autonomously collect air and water quality data. This required a deep dive into both hardware and software, blending the worlds of IoT and Robotics.</p>
      <p>The firmware was written in C++ and ran on a custom-built flight controller. I used PlatformIO for the development environment, which made managing libraries and dependencies a breeze. The drone was equipped with various sensors, including a particulate matter sensor and a pH sensor.</p>
      <p>Data was streamed in real-time to a ground station, which was a web application built with React and ASP.NET Core. This allowed for immediate analysis of the collected data.</p>
      <p>The project taught me a lot about the challenges of building autonomous systems and the importance of robust error handling. I'm proud of what I was able to achieve, and I'm excited to continue working on projects at the intersection of IoT and robotics.</p>
    `,
    comments: [
      { id: "3", author: "Alice", text: "Incredible project! I'd love to see a demo of the drone in action." }
    ]
  }
];

export const sectionClass = {
    title: "text-3xl md:text-5xl text-center text-[#1b3221] font-extrabold font-serif",
    text: "text-lg text-center text-[#46594a]",
    title_color: "#1b3221",
    text_color: "#677e7c"
}
