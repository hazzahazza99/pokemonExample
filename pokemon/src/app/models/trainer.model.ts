export interface Trainer {
    trainerID: number;
    trainerName: string;
    trainerAge: number;
    trainerBadge: string;
    isGymLeader: boolean;
  }
  
  export interface CreateTrainer {
    trainerName: string;
    trainerAge: number;
    trainerBadge: string;
    isGymLeader: boolean;
  }
  