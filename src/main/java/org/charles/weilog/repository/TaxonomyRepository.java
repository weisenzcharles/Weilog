package org.charles.weilog.repository;

import org.charles.weilog.domain.Taxonomy;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

public interface TaxonomyRepository extends JpaRepository<Taxonomy, Long>, JpaSpecificationExecutor<Taxonomy> {
}