package org.charles.weilog.repository;

import org.charles.weilog.domain.Metadata;
import org.springframework.data.jpa.repository.JpaRepository;

public interface MetadataRepository extends JpaRepository<Metadata, Long> {
}
