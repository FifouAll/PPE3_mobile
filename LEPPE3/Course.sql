-- phpMyAdmin SQL Dump
-- version 4.6.6deb4
-- https://www.phpmyadmin.net/
--
-- Client :  localhost:3306
-- Généré le :  Ven 10 Mai 2019 à 07:48
-- Version du serveur :  10.1.26-MariaDB-0+deb9u1
-- Version de PHP :  7.0.27-0+deb9u1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `Course`
--

DELIMITER $$
--
-- Fonctions
--
CREATE DEFINER=`sio`@`%` FUNCTION `addEquipe` (`nomequipe` VARCHAR(300), `couleurequipe` VARCHAR(300)) RETURNS VARCHAR(500) CHARSET utf8mb4 NO SQL
BEGIN
	IF(EXISTS(SELECT * FROM Equipe WHERE nomequipe != " "))
    	THEN
        	IF(EXISTS(SELECT * FROM Equipe WHERE couleurequipe != " "))
            THEN
        		INSERT INTO Equipe(nom_equipe,couleur_equipe) values ( nomequipe, couleurequipe);   
        		RETURN "Ajout de l'équipe";
            ELSE
            	RETURN "Couleur vide?";
            END IF;
    ELSE
        RETURN "Erreur dans l'équipe";
   END IF;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `Course`
--

CREATE TABLE `Course` (
  `depart_course` date NOT NULL,
  `fin_course` date NOT NULL,
  `lieu_course` varchar(500) NOT NULL,
  `nom_course` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `Course`
--

INSERT INTO `Course` (`depart_course`, `fin_course`, `lieu_course`, `nom_course`) VALUES
('0000-00-00', '0000-00-00', 'Bar-Le-Duc', 'Pikachu'),
('0000-00-00', '0000-00-00', 'test', 'test'),
('0000-00-00', '0000-00-00', 'test', 'test'),
('0000-00-00', '0000-00-00', 'Bar-Le-Duc', 'Pikachu'),
('0000-00-00', '0000-00-00', 'test', 'test'),
('0000-00-00', '0000-00-00', 'test', 'test');

-- --------------------------------------------------------

--
-- Structure de la table `Equipe`
--

CREATE TABLE `Equipe` (
  `id_equipe` int(11) NOT NULL,
  `nom_equipe` varchar(500) NOT NULL,
  `couleur_equipe` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `Equipe`
--

INSERT INTO `Equipe` (`id_equipe`, `nom_equipe`, `couleur_equipe`) VALUES
(1, 'Equipe 1', 'rouge'),
(2, 'Equipe 2', 'jaune'),
(3, 'Equipe 3', 'vert'),
(4, 'Segpa', 'Grise'),
(5, 'test', 'rubis'),
(6, 'test2', 'saphir');

-- --------------------------------------------------------

--
-- Structure de la table `Localisation`
--

CREATE TABLE `Localisation` (
  `id_localisation` int(11) NOT NULL,
  `date_actuelle` date NOT NULL,
  `temps_reel` varchar(500) NOT NULL,
  `longitude` varchar(500) NOT NULL,
  `latitude` varchar(500) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `Localisation`
--

INSERT INTO `Localisation` (`id_localisation`, `date_actuelle`, `temps_reel`, `longitude`, `latitude`, `id`) VALUES
(2, '2018-10-17', '', '5.1582', '48.7736', 4),
(3, '2018-10-17', '', '5.1581', '48.7735', 5),
(7, '2018-10-17', '', '5.1575', '48.7730', 6);

-- --------------------------------------------------------

--
-- Structure de la table `Participant`
--

CREATE TABLE `Participant` (
  `id` int(11) NOT NULL,
  `motDePasse` varchar(50) NOT NULL DEFAULT '0',
  `nom` varchar(500) NOT NULL,
  `prenom` varchar(500) NOT NULL,
  `mail` varchar(500) NOT NULL,
  `age` int(11) NOT NULL,
  `telephone` varchar(10) NOT NULL,
  `sexe` char(1) NOT NULL,
  `id_equipe` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `Participant`
--

INSERT INTO `Participant` (`id`, `motDePasse`, `nom`, `prenom`, `mail`, `age`, `telephone`, `sexe`, `id_equipe`) VALUES
(4, '0', 'heles', 'julien', 'jhels@gmail.com', 21, '0608595743', 'M', 1),
(5, '0', 'toto', 'toto', 'toto.toto@gmail.com', 18, '068596321', 'M', 1),
(6, '0', 'machin', 'truc', 'mach.truc@gmail.com', 20, '0685214563', 'F', 2),
(7, '0', 'ethb', 'jtyn', 'dtrne.erb@gmail.com', 18, '0352169584', 'F', 3);

--
-- Index pour les tables exportées
--

--
-- Index pour la table `Equipe`
--
ALTER TABLE `Equipe`
  ADD PRIMARY KEY (`id_equipe`);

--
-- Index pour la table `Localisation`
--
ALTER TABLE `Localisation`
  ADD PRIMARY KEY (`id_localisation`),
  ADD KEY `Localisation_Participant_FK` (`id`);

--
-- Index pour la table `Participant`
--
ALTER TABLE `Participant`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Participant_Equipe_FK` (`id_equipe`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `Equipe`
--
ALTER TABLE `Equipe`
  MODIFY `id_equipe` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT pour la table `Localisation`
--
ALTER TABLE `Localisation`
  MODIFY `id_localisation` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT pour la table `Participant`
--
ALTER TABLE `Participant`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `Localisation`
--
ALTER TABLE `Localisation`
  ADD CONSTRAINT `Localisation_Participant_FK` FOREIGN KEY (`id`) REFERENCES `Participant` (`id`);

--
-- Contraintes pour la table `Participant`
--
ALTER TABLE `Participant`
  ADD CONSTRAINT `Participant_Equipe_FK` FOREIGN KEY (`id_equipe`) REFERENCES `Equipe` (`id_equipe`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
