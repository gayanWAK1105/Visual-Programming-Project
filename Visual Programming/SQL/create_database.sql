CREATE DATABASE IF NOT EXISTS algoride_db;
USE algoride_db;

CREATE TABLE IF NOT EXISTS players (
    player_id INT AUTO_INCREMENT PRIMARY KEY,
    player_name VARCHAR(100) NOT NULL UNIQUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS game_scores (
    score_id INT AUTO_INCREMENT PRIMARY KEY,
    player_id INT NOT NULL,
    game_type ENUM('Addition', 'Subtraction', 'Multiplication', 'Division') NOT NULL,
    level INT NOT NULL,
    high_score INT NOT NULL DEFAULT 0,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (player_id) REFERENCES players(player_id) ON DELETE CASCADE,
    UNIQUE KEY unique_player_game_level (player_id, game_type, level)
);
