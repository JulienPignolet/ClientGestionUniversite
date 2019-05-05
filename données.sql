-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Hôte : mysql1.yulpa.io
-- Généré le :  Dim 05 mai 2019 à 13:42
-- Version du serveur :  5.5.57-0+deb7u1-log
-- Version de PHP :  7.0.33-1~dotdeb+8.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `535_partages51`
--

--
-- Déchargement des données de la table `annee`
--

INSERT INTO `annee` (`id`, `diplome_id`, `libelle`) VALUES
(639, 886, 'L1 MATH'),
(640, 886, 'L2 MATH'),
(641, 887, 'L1 MECA'),
(642, 887, 'L2 MECA'),
(643, 885, 'M1 INFO\r\n'),
(644, 885, 'M2 INFO');

--
-- Déchargement des données de la table `categorie_personnel`
--

INSERT INTO `categorie_personnel` (`id`, `libelle`, `volume_horaire`) VALUES
(268, 'MC', 192),
(269, 'PRAG', 384),
(270, 'Prof des universités', 192);

--
-- Déchargement des données de la table `diplome`
--

INSERT INTO `diplome` (`id`, `libelle`) VALUES
(885, 'Master informatique'),
(886, 'Licence mathématique'),
(887, 'Licence mécanique');

--
-- Déchargement des données de la table `element_constitutif`
--

INSERT INTO `element_constitutif` (`id`, `ue_id`, `libelle`) VALUES
(220, 334, 'Statistique Euler'),
(221, 335, 'Statistique Euler PointCarré'),
(222, 336, 'Probabilité conditionnelle'),
(223, 337, 'Probabilité exponentielle'),
(225, 338, 'Mécanique des fluides'),
(226, 339, 'Mécanique thermique'),
(227, 340, 'Mécanique quantique'),
(228, 341, 'Mécanique précisionnelle'),
(229, 342, 'MVC'),
(230, 343, 'Singleton'),
(231, 344, 'Android'),
(232, 345, 'IOS');

--
-- Déchargement des données de la table `periode`
--

INSERT INTO `periode` (`id`, `annee_id`, `libelle`) VALUES
(458, 639, 's1'),
(459, 639, 's2'),
(460, 640, 'semestre 1'),
(461, 640, 'semestre 2'),
(462, 641, 'semestre 2'),
(463, 641, 'semestre 1'),
(464, 642, 'semestre 2'),
(465, 642, 'semestre 1'),
(466, 643, 'semestre 2'),
(467, 643, 'semestre 1'),
(468, 644, 'semestre 2'),
(469, 644, 'semestre 1');

--
-- Déchargement des données de la table `personnel`
--

INSERT INTO `personnel` (`id`, `nom`, `prenom`, `categorie_id`) VALUES
(213, 'Jean', 'Pierre', 268),
(214, 'Lary', 'Bambelle', 269),
(215, 'Al', 'Kollick', 270);

--
-- Déchargement des données de la table `ratio`
--

INSERT INTO `ratio` (`type_id`, `categorie_id`, `ratio`) VALUES
(1, 268, 1.5),
(1, 269, 1.5),
(1, 270, 2),
(28, 268, 1),
(28, 269, 1),
(28, 270, 1),
(29, 268, 0.66),
(29, 269, 0.66),
(29, 270, 0.33);

--
-- Déchargement des données de la table `type_cours`
--

INSERT INTO `type_cours` (`id`, `libelle`) VALUES
(1, 'CM'),
(28, 'TD'),
(29, 'TP\r\n');

--
-- Déchargement des données de la table `unite_enseignement`
--

INSERT INTO `unite_enseignement` (`id`, `periode_id`, `libelle`) VALUES
(334, 458, 'Statistique'),
(335, 459, 'Statistique avancée'),
(336, 460, 'Probabilité'),
(337, 461, 'Probabilité avancée'),
(338, 463, 'Mécanique'),
(339, 462, 'Mécanique avancée'),
(340, 465, 'Mécanique très avancée'),
(341, 464, 'Mécanique expert'),
(342, 467, 'Design pattern'),
(343, 466, 'Design pattern mode expert'),
(344, 469, 'Appli mobile'),
(345, 468, 'Appli très mobile');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
