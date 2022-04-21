package org.charles.weilog.repository;

import org.charles.weilog.domain.Metadata;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 * 元数据仓库。
 */
public interface MetadataRepository extends JpaRepository<Metadata, Long> {
}
